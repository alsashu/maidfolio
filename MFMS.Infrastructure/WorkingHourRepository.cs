using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class WorkingHourRepository: IWorkingHourRepository
    {
        public EF_DbContext _dbContext;

        public WorkingHourRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public WorkingHour AddWorkingHour(WorkingHour workingHour)
        {
            _dbContext.Add(workingHour);
            _dbContext.SaveChanges();
            return workingHour;
        }

        public bool DeleteWorkingHour(int id)
        {
            var success = false;
            var result = _dbContext.WorkingHour.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.WorkingHour.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<WorkingHour> GetAllWorkingHour()
        {
            return _dbContext.WorkingHour.ToList();
        }

        public WorkingHour GetWorkingHourById(int id)
        {
            var row = _dbContext.WorkingHour.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public WorkingHour UpdateWorkingHour(WorkingHour workingHour)
        {
            _dbContext.SaveChanges();
            return workingHour;
        }
    }
}
