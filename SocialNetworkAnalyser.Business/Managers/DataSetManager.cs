using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SocialNetworkAnalyser.Business.Managers
{
    public class DataSetManager
    {
        public DataSetManager()
        {
        }


        public bool ImportDataSet(Stream inputStream)
        {
            try
            {
                if (inputStream == null || inputStream.Length == 0)
                    throw new ArgumentException("Empty stream");

                var importedDataSet = new Dictionary<int, HashSet<int>>();

                using (var sReader = new StreamReader(inputStream))
                {
                    while (!sReader.EndOfStream)
                    {
                        string sourceLine = sReader.ReadLine();
                        var friendsIDs = ParseFriendsIDs(sourceLine);

                        if (friendsIDs == null)
                            return false;

                        if (friendsIDs[0] != friendsIDs[1])
                            AddFriendshipToDataSet(importedDataSet, friendsIDs);
                    }
                }

                using (var repository = new UnitOfWorkFactory())
                {
                    var dataSet = DataSet.Create(DateTime.Now.ToShortDateString());

                    //add all unique users to database 
                    var users = new List<User>();
                    foreach (var user in importedDataSet)
                        users.Add(User.Create(user.Key, dataSet.Id));

                    //add all friendships
                    var friendships = new List<Friendship>();
                    foreach (var user in users)
                    {
                        var friends = users.Where(u => importedDataSet[user.SocialNetworkId].Contains(u.SocialNetworkId)).ToList();
                        var friendship = Friendship.Create(user.SocialNetworkId, dataSet.Id, friends);

                        friendships.Add(friendship);
                    }

                    
                    repository.DataSets.Add(dataSet);
                    repository.Users.Add(users);
                    repository.Friendships.Add(friendships);

                    repository.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                //log error
                return false;
            }
        }

        private void AddFriendshipToDataSet(Dictionary<int, HashSet<int>> importedDataSet, int[] friendsIDs)
        {
            int userId;
            int friendId;

            for (int i = 0; i < friendsIDs.Length; i++)
            {
                userId = friendsIDs[i];
                friendId = (i == 0) ? friendsIDs[i + 1] : friendsIDs[i - 1];

                if (importedDataSet.ContainsKey(userId))
                    importedDataSet[userId].Add(friendId);
                else
                    importedDataSet.Add(userId, new HashSet<int>() { friendId });
            }
        }

        private int[] ParseFriendsIDs(string line)
        {
            try
            {
                if (string.IsNullOrEmpty(line))
                    return null;

                var parsedIDs = line.Trim().Split(' ');
                if (parsedIDs.Length != 2)
                    return null;

                return new int[] { int.Parse(parsedIDs[0]), int.Parse(parsedIDs[1]) };
            }
            catch (Exception ex)
            {
                //LogError like string.Format("Line '{0}' not parsed", line)
                return null;
            }
        }
    }
}
