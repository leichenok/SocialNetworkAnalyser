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

        public int OwnerId { get; set; }

        public ICollection<User> Users { get; set; }

        public Friendship()
        {
            Users = new List<User>();
        }


        public static Friendship Create(int ownerId, Guid dataSetId, ICollection<User> users = null)
        {
            return new Friendship()
            {
                Id = Guid.NewGuid(),
                OwnerId = ownerId,
                DataSetId = dataSetId,
                Users = users ?? new List<User>()
            };
        }
    }
}
