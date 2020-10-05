using SocialNetworkAnalyser.Data.Contexts;
using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;

namespace SocialNetworkAnalyser.Data.Repositories
{
    public class FriendshipRepository : RepositoryBase, IFriendshipRepository
    {
        public FriendshipRepository(AppContext context) 
            : base(context)
        {
        }


        public void Add(IEnumerable<Friendship> friendships)
        {
            try
            {
                Context.BulkInsert(friendships, options => 
                {
                    options.IncludeGraph = true;
                    options.AutoMapOutputDirection = false;
                });
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public double GetAverageFriendsCountForEachPerson(Guid dataSetId)
        {
            var average = Context.Friendships.
                AsNoTracking().
                Where(f => f.DataSetId == dataSetId).
                Average(f => f.Friends.Count);

            return average;
        }
    }
}
