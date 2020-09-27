using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IDataSetRepository DataSets { get; }
        IFriendshipRepository Friendships { get; }
        IUserRepository Users { get; }

        void Commit();
    }
}
