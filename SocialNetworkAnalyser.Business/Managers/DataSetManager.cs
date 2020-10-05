using SocialNetworkAnalyser.Business.Logging;
using SocialNetworkAnalyser.Business.Models;
using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SocialNetworkAnalyser.Business.Managers
{
    public class DataSetManager : ManagerBase
    {
        public DataSetManager()
        {
        }


        public DataSet Get(Guid id)
        {
            try
            {
                using (var repository = NewRepositoryFactory())
                {
                    return repository.DataSets.Get(id);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
        public List<DataSet> GetAll()
        {
            try
            {
                using (var repository = NewRepositoryFactory())
                {
                    return repository.DataSets.GetAll();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new List<DataSet>();
            }
        }

        public ImportDataSetResult ImportDataSet(Stream inputStream, string dataSetName)
        {
            if (inputStream == null || inputStream.Length == 0)
                throw new ArgumentException("Null or empty file stream");

            try
            {
                var parsedData = new Dictionary<int, HashSet<int>>();

                using (var sReader = new StreamReader(inputStream))
                {
                    int lineIndex = 1;
                    while (!sReader.EndOfStream)
                    {
                        string sourceLine = sReader.ReadLine();
                        if (string.IsNullOrEmpty(sourceLine))
                        {
                            lineIndex++;
                            continue;
                        }

                        var friendsIDs = ParseFriendsIDs(sourceLine);

                        if (friendsIDs == null)
                        {
                            string errorMessage = $"Incorrect line {lineIndex}: '{sourceLine}'";
                            var importResult = new ImportDataSetResult(false, errorMessage);

                            return importResult;
                        }

                        if (friendsIDs[0] != friendsIDs[1])
                            AddFriendIdToFriendship(parsedData, friendsIDs);

                        lineIndex++;
                    }
                }

                Save(parsedData, dataSetName);

                return new ImportDataSetResult(true);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ImportDataSetResult(false, ex.Message);
            }
        }


        private void Save(Dictionary<int, HashSet<int>> parsedData, string dataSetName)
        {
            using (var repository = NewRepositoryFactory())
            {
                var dataSet = DataSet.Create(dataSetName);

                //create all unique friends
                var friends = new List<Friend>();
                foreach (var friend in parsedData)
                    friends.Add(Friend.Create(friend.Key, dataSet.Id));

                //create friendships for each user(friend)
                var friendships = new List<Friendship>();
                foreach (var friend in friends)
                {
                    var mutualFriends = friends.Where(f => parsedData[friend.SocialNetworkId].Contains(f.SocialNetworkId)).ToList();
                    var friendship = Friendship.Create(friend.Id, dataSet.Id, mutualFriends);

                    friendships.Add(friendship);
                }

                repository.DataSets.Add(dataSet);
                repository.Friendships.Add(friendships);

                repository.Commit();
            }
        }

        private void AddFriendIdToFriendship(Dictionary<int, HashSet<int>> parsedData, int[] friendsIDs)
        {
            int firstFriendId;
            int secondfriendId;

            for (int i = 0; i < friendsIDs.Length; i++)
            {
                firstFriendId = friendsIDs[i];
                secondfriendId = (i == 0) ? friendsIDs[i + 1] : friendsIDs[i - 1];

                if (parsedData.ContainsKey(firstFriendId))
                    parsedData[firstFriendId].Add(secondfriendId);
                else
                    parsedData.Add(firstFriendId, new HashSet<int>() { secondfriendId });
            }
        }
        private int[] ParseFriendsIDs(string line)
        {
            try
            {
                var parsedIDs = line.Trim().Split(' ');
                if (parsedIDs.Length != 2)
                    return null;

                return new int[] { int.Parse(parsedIDs[0]), int.Parse(parsedIDs[1]) };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
    }
}
