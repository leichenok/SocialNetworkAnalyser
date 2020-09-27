using SocialNetworkAnalyser.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Get(int id);
        List<User> GetAll();

        void Add(IEnumerable<User> users);

        int Count();
    }
}
