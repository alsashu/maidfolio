using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class RoleRepository: IRoleRepository
    {
        public EF_DbContext _dbContext;

        public RoleRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Role AddRole(Role role)
        {
            _dbContext.Add(role);
            _dbContext.SaveChanges();
            return role;
        }

        public bool DeleteRole(int id)
        {
            var success = false;
            var result = _dbContext.Role.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.Role.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<Role> GetAllRole()
        {
            return _dbContext.Role.ToList();
        }

        public Role GetRoleById(int id)
        {
            var row = _dbContext.Role.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public Role UpdateRole(Role role)
        {
            _dbContext.SaveChanges();
            return role;
        }
    }
}
