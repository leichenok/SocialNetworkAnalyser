using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories.Interfaces
{
    public interface IRepositoryFactory : IDisposable
    {
        IDataSetRepository DataSets { get; }
        IFriendshipRepository Friendships { get; }
        IFriendRepository Friends { get; }

        bool Disposed { get; }

        void Commit();
    }
}
