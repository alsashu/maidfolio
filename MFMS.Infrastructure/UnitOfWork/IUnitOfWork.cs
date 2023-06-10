using MFMS.Domain;
using MFMS.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Users> IUsersRepository { get; }
        #endregion
    }
}
