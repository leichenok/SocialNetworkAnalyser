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

       
        public User Get(int id)
        {
            try
            {
                return Context.Users.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
        public List<User> GetAll()
        {
            try
            {
                return Context.Users.ToList();
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

        public int Count()
        {
            try
            {
                return Context.Users.Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
