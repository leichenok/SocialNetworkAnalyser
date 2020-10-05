using System;
using System.Collections.Generic;

namespace SocialNetworkAnalyser.Data.Entities
{
    public class Friend
    {
        public Guid Id { get; set; }
        public Guid DataSetId { get; set; }

        public int SocialNetworkId { get; set; }

        public ICollection<Friendship> Friendships { get; set; }

        public Friend()
        {
            Friendships = new List<Friendship>();
        }

        public static Friend Create(int socialNetworkId, Guid dataSetId, ICollection<Friendship> friendships = null)
        {
            return new Friend()
            {
                Id = Guid.NewGuid(),
                DataSetId = dataSetId,
                SocialNetworkId = socialNetworkId,
                Friendships = friendships ?? new List<Friendship>()
            };
        }
    }
}
