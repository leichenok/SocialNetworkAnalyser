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
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(AppContext context) 
            : base(context)
        {
        }

       
        public User Get(int id, Guid dataSetID)
        {
            try
            {
                return Context.Users.FirstOrDefault(u => u.SocialNetworkId == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
        public List<User> GetAll(Guid dataSetID)
        {
            try
            {
                return Context.Users.Where(u => u.DataSetId == dataSetID).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public void Add(IEnumerable<User> users)
        {
            try
            {
                Context.Users.AddRange(users);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }       

        public int Count(Guid dataSetID)
        {
            try
            {
                return Context.Users.Count(u => u.DataSetId == dataSetID);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
