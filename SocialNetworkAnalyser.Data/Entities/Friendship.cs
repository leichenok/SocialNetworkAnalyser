using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Entities
{
    public class Friendship
    {
        public Guid Id { get; set; }
        public Guid DataSetId { get; set; }

        public Guid MutualFriendId { get; set; }

        public ICollection<Friend> Friends { get; set; }

        public Friendship()
        {
            Friends = new List<Friend>();
        }


        public static Friendship Create(Guid mutualFriendId, Guid dataSetId, ICollection<Friend> users = null)
        {
            return new Friendship()
            {
                Id = Guid.NewGuid(),
                MutualFriendId = mutualFriendId,
                DataSetId = dataSetId,
                Friends = users ?? new List<Friend>()
            };
        }
    }
}
