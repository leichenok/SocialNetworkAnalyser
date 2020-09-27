using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


                    var dataSet = new DataSet() { Id = Guid.NewGuid(), Created = DateTime.Now, Name = DateTime.Now.ToShortDateString() };
                    repository.DataSets.Add(dataSet);



                    foreach (var item in importedDataSet)
                    {
                        var userFriends = new List<User>();
                        foreach (var friendId in item.Value)
                            userFriends.Add(new User() { Id = friendId, DataSetId = dataSet.Id });


                        var friendship = new Friendship() { Id = Guid.NewGuid(), DataSetId = dataSet.Id, UserId = item.Key, Friends = userFriends };
                        repository.Friendships.Add(friendship);
                    }


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
