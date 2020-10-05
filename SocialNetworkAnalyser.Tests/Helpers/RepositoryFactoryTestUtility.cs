using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using SocialNetworkAnalyser.Tests.Helpers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Tests.Helpers
{
    public class RepositoryFactoryTestUtility : IRepositoryFactory
    {
        public IDataSetRepository DataSets { get; set; }
        public IFriendshipRepository Friendships { get; set; }
        public IFriendRepository Friends { get; set; }

        public bool Disposed => false;

        public RepositoryFactoryTestUtility()
        {
        }

        public void Commit()
        {
        }
        public void Dispose()
        {
        }
    }
}
