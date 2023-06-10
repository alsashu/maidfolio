using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class RoleMasterRepository: IRoleMasterRepository
    {
        public EF_DbContext _dbContext;

        public RoleMasterRepository(EF_DbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public RoleMaster AddRoleMaster(RoleMaster roleMaster)
        {
            _dbContext.Add(roleMaster);
            _dbContext.SaveChanges();
            return roleMaster;
        }

        public bool DeleteRoleMaster(int id)
        {
            var success = false;
            var result = _dbContext.RoleMaster.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.RoleMaster.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<RoleMaster> GetAllRoleMaster()
        {
            return _dbContext.RoleMaster.ToList();
        }

        public RoleMaster GetRoleMasterById(int id)
        {
            var row = _dbContext.RoleMaster.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public RoleMaster UpdateRoleMaster(RoleMaster roleMaster)
        {
            _dbContext.SaveChanges();
            return roleMaster;
        }
    }
}
