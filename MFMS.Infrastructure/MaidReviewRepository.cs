using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class MaidReviewRepository : IMaidReviewRepository
    {
        public EF_DbContext _dbContext;

        public MaidReviewRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MaidReview AddMaidReview(MaidReview maidReview)
        {
            _dbContext.Add(maidReview);
            _dbContext.SaveChanges();
            return maidReview;
        }

        public bool DeleteMaidReview(long id)
        {
            var success = false;
            var result = _dbContext.MaidReviews.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.MaidReviews.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<MaidReview> GetAllMaidReview()
        {
            return _dbContext.MaidReviews.ToList();
        }

        public MaidReview GetMaidReviewById(long id)
        {
            var row = _dbContext.MaidReviews.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public MaidReview UpdateMaidReview(MaidReview maidReview)
        {
            _dbContext.SaveChanges();
            return maidReview;
        }
    }
}
