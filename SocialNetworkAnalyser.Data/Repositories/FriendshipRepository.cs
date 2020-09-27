using SocialNetworkAnalyser.Data.Contexts;
using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories
{
    public class FriendshipRepository : RepositoryBase, IFriendshipRepository
    {
        public FriendshipRepository(AppContext context) 
            : base(context)
        {
        }


        public Friendship Get(Guid id)
        {
            try
            {
                return Context.Friendships.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
        public List<Friendship> GetAll()
        {
            try
            {
                return Context.Friendships.ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public void Add(Friendship friendship)
        {
            try
            {
                Context.Friendships.Add(friendship);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
