using System;
using System.Collections.Generic;

namespace SocialNetworkAnalyser.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid DataSetId { get; set; }

        public int SocialNetworkId { get; set; }

        public ICollection<Friendship> Friendships { get; set; }

        public User()
        {
            Friendships = new List<Friendship>();
        }

        public static User Create(int socialNetworkId, Guid dataSetId, ICollection<Friendship> friendships = null)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                DataSetId = dataSetId,
                SocialNetworkId = socialNetworkId,
                Friendships = friendships ?? new List<Friendship>()
            };
        }
    }
}
