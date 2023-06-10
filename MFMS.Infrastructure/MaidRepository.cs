using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class MaidRepository: IMaidRepository
    {
        public EF_DbContext _dbContext;

        public MaidRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Maid Add(Maid maid)
        {
            _dbContext.Add(maid);
            _dbContext.SaveChanges();
            return maid;
        }

        public bool Delete(int id)
        {
            var success = false;
            var result = _dbContext.Maids.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.Maids.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<Maid> GetAll()
        {
            return _dbContext.Maids.ToList();
        }

        public Maid GetById(int id)
        {
            var row = _dbContext.Maids.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public Maid Update(Maid maid)
        {
            throw new NotImplementedException();
        }
    }
}
