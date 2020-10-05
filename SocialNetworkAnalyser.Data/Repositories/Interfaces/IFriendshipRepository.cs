using SocialNetworkAnalyser.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories.Interfaces
{
    public interface IFriendshipRepository
    {
        void Add(IEnumerable<Friendship> friendships);
        double GetAverageFriendsCountForEachPerson(Guid dataSetID);
    }
}
