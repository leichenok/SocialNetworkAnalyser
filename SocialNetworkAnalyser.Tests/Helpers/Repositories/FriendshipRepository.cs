using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Tests.Helpers.Repositories
{
    public class FriendshipRepository : IFriendshipRepository
    {
        public List<Friendship> Friendships = new List<Friendship>();

        public void Add(IEnumerable<Friendship> friendships)
        {
            Friendships.AddRange(friendships);
        }

        public double GetAverageFriendsCountForEachPerson(Guid dataSetID)
        {
            return Friendships.Where(f => f.DataSetId == dataSetID).Average(f => f.Friends.Count);
        }
    }
}
