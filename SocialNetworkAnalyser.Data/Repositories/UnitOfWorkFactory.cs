using SocialNetworkAnalyser.Data.Contexts;
using SocialNetworkAnalyser.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Data.Repositories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory, IDisposable
    {
        private AppContext _context = new AppContext();

        private bool _disposed = false;

        private IDataSetRepository _dataSetRepository;
        private IFriendshipRepository _friendshipRepository;
        private IUserRepository _userRepository;

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
        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
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
