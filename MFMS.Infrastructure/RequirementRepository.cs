using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class RequirementRepository : IRequirementRepository
    {
        public EF_DbContext _dbContext;

        public RequirementRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Requirement AddRequirement(Requirement requirement)
        {
            _dbContext.Add(requirement);
            _dbContext.SaveChanges();
            return requirement;
        }

        public bool DeleteRequirement(long id)
        {
            var success = false;
            var result = _dbContext.Requirements.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.Requirements.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<Requirement> GetAllRequirement()
        {
            return _dbContext.Requirements.ToList();
        }

        public Requirement GetRequirementById(long id)
        {
            var row = _dbContext.Requirements.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public Requirement UpdateRequirement(Requirement requirement)
        {
            _dbContext.SaveChanges();
            return requirement;
        }
    }
}
