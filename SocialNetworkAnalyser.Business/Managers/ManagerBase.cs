using SocialNetworkAnalyser.Data.Repositories;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Business.Managers
{
    public class ManagerBase
    {
        private IRepositoryFactory _repositoryFactory;

        public void SetRepositoryFactory(IRepositoryFactory newRepositoryFactory)
        {
            _repositoryFactory = newRepositoryFactory;
        }
        protected IRepositoryFactory NewRepositoryFactory()
        {
            if (_repositoryFactory == null || _repositoryFactory.Disposed)
                _repositoryFactory = new RepositoryFactory();

            return _repositoryFactory;
        }
    }
}
