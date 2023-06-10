using MFMS.Application.Repository;
using MFMS.DataTransferObject;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class UsersRepository: IUsersRepository
    {
        public EF_DbContext _dbContext;

        public UsersRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Users Add(Users Users)
        {
            _dbContext.Add(Users);
            _dbContext.SaveChanges();
            return Users;
        }

        public bool Delete(int id)
        {
            var success = false;
            var result = _dbContext.Users.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.Users.Remove(result);
                _dbContext.SaveChanges();
                 success=true;
            }
            return success;
        }

        public IEnumerable<Users> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public Users GetById(int id)
        {
            var row = _dbContext.Users.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public Users Update(Users Users)
        {
            throw new NotImplementedException();
        }
    }
}
