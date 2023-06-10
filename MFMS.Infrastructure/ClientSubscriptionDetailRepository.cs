using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class ClientSubscriptionDetailRepository : IClientSubscriptionDetailRepository
    {
        public EF_DbContext _dbContext;

        public ClientSubscriptionDetailRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ClientSubscriptionDetail AddClientSubscriptionDetail(ClientSubscriptionDetail clientSubscriptionDetail)
        {
            _dbContext.Add(clientSubscriptionDetail);
            _dbContext.SaveChanges();
            return clientSubscriptionDetail;
        }

        public bool DeleteClientSubscriptionDetail(long id)
        {
            var success = false;
            var result = _dbContext.ClientSubscriptionDetails.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.ClientSubscriptionDetails.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<ClientSubscriptionDetail> GetAllClientSubscriptionDetail()
        {
            return _dbContext.ClientSubscriptionDetails.ToList();
        }

        public IEnumerable<ClientSubscriptionDetail> GetClientSubscriptionDetailByClientId(long clientId)
        {
            var row = _dbContext.ClientSubscriptionDetails.Where(t => t.client_id.Equals(clientId)).ToList();
            if (row != null)
            {
                return row;
            }
            return null;
        }

        public ClientSubscriptionDetail GetClientSubscriptionDetailById(long id)
        {
            var row = _dbContext.ClientSubscriptionDetails.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }

        public ClientSubscriptionDetail UpdateClientSubscriptionDetail(ClientSubscriptionDetail clientSubscriptionDetail)
        {
            _dbContext.SaveChanges();
            return clientSubscriptionDetail;
        }
    }
}
