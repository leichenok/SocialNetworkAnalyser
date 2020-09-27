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
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<User> Friends { get; set; }

        public Friendship()
        {
            Friends = new List<User>();
        }
    }
}
