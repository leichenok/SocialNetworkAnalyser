using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Tests.Helpers.Repositories
{
    public class FriendsRepository : IFriendRepository
    {
        public List<Friend> Friends = new List<Friend>();

        public int Count(Guid dataSetID)
        {
            return Friends.Count(f => f.DataSetId == dataSetID);
        }
    }
}
