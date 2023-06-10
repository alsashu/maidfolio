using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class SalaryRangeRepository: ISalaryRangeRepository
    {
        public EF_DbContext _dbContext;

        public SalaryRangeRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SalaryRange AddSalaryRange(SalaryRange salaryRange)
        {
            _dbContext.Add(salaryRange);
            _dbContext.SaveChanges();
            return salaryRange;
        }

        public bool DeleteSalaryRange(int id)
        {
            var success = false;
            var result = _dbContext.SalaryRanges.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.SalaryRanges.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<SalaryRange> GetAllSalaryRange()
        {
            return _dbContext.SalaryRanges.ToList();
        }

        public SalaryRange GetSalaryRangeById(int id)
        {
            var row = _dbContext.SalaryRanges.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public SalaryRange UpdateSalaryRange(SalaryRange salaryRange)
        {
            _dbContext.SaveChanges();
            return salaryRange;
        }
    }
}
