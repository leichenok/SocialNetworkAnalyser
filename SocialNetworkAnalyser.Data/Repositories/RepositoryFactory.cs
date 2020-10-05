using SocialNetworkAnalyser.Data.Contexts;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private AppContext _context;

        private bool _disposed = false;

        private IDataSetRepository _dataSetRepository;
        private IFriendshipRepository _friendshipRepository;
        private IFriendRepository _friendRepository;

        public IDataSetRepository DataSets
        {
            get
            {
                if (_dataSetRepository == null)
                    _dataSetRepository = new DataSetRepository(_context);

                return _dataSetRepository;
            }
        }
        public IFriendshipRepository Friendships
        {
            get
            {
                if (_friendshipRepository == null)
                    _friendshipRepository = new FriendshipRepository(_context);

                return _friendshipRepository;
            }
        }
        public IFriendRepository Friends
        {
            get
            {
                if (_friendRepository == null)
                    _friendRepository = new FriendRepository(_context);

                return _friendRepository;
            }
        }

        public bool Disposed => _disposed;

        public RepositoryFactory()
        {
            _context = new AppContext();
            _context.Configuration.AutoDetectChangesEnabled = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
