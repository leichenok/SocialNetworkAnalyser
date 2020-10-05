using SocialNetworkAnalyser.Tests.Helpers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Tests.Helpers
{
    public class BaseTestManager
    {
        protected DataSetRepository DataSetRepository { get; private set; }
        protected FriendshipRepository FriendshipRepository { get; private set; }
        protected FriendsRepository FriendsRepository { get; private set; }

        protected RepositoryFactoryTestUtility RepositoryFactory { get; private set; }

        public virtual void SetUp()
        {
            DataSetRepository = new DataSetRepository();
            FriendshipRepository = new FriendshipRepository();
            FriendsRepository = new FriendsRepository();

            RepositoryFactory = new RepositoryFactoryTestUtility() { DataSets = DataSetRepository, Friendships = FriendshipRepository, Friends = FriendsRepository };
        }
    }
}
