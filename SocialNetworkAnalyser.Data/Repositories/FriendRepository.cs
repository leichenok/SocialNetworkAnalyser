using SocialNetworkAnalyser.Data.Contexts;
using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories
{
    public class FriendRepository : RepositoryBase, IFriendRepository
    {
        public FriendRepository(AppContext context) 
            : base(context)
        {
        }


        public int Count(Guid dataSetID)
        {
            try
            {
                return Context.Friends
                    .AsNoTracking().
                    Count(f => f.DataSetId == dataSetID);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
