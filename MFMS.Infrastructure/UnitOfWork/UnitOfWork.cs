using MFMS.Domain;
using MFMS.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork
    {
        #region Private member variables...
        private EF_DbContext _dbContext = null;
        private GenericRepository<Users> _usersRepository;
        #endregion

        #region Public Constructor...
        public UnitOfWork(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
            //_dbContext.Database.Initialize(true);
        }
        #endregion

        /// <summary>
        /// Get/Set Property for api client repository.
        /// </summary>
        public GenericRepository<Users> UsersRepository
        {
            get
            {
                if (this._usersRepository == null)
                    this._usersRepository = new GenericRepository<Users>(_dbContext);
                return _usersRepository;
            }
        }
    }
}
