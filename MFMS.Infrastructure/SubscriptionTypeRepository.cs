using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class SubscriptionTypeRepository: ISubscriptionTypeRepository
    {
        public EF_DbContext _dbContext;

        public SubscriptionTypeRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SubscriptionType AddSubscriptionType(SubscriptionType subscriptionType)
        {
            _dbContext.Add(subscriptionType);
            _dbContext.SaveChanges();
            return subscriptionType;
        }

        public bool DeleteSubscriptionType(int id)
        {
            var success = false;
            var result = _dbContext.SubscriptionTypes.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.SubscriptionTypes.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<SubscriptionType> GetAllSubscriptionType()
        {
            return _dbContext.SubscriptionTypes.ToList();
        }

        public SubscriptionType GetSubscriptionTypeById(int id)
        {
            var row = _dbContext.SubscriptionTypes.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public SubscriptionType UpdateSubscriptionType(SubscriptionType subscriptionType)
        {
            _dbContext.SaveChanges();
            return subscriptionType;
        }
    }
}
