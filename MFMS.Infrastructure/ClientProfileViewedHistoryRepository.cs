using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class ClientProfileViewedHistoryRepository : IClientProfileViewedHistoryRepository
    {
        public EF_DbContext _dbContext;

        public ClientProfileViewedHistoryRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ClientProfileViewedHistory AddClientProfileViewedHistory(ClientProfileViewedHistory clientProfileViewedHistory)
        {
            _dbContext.Add(clientProfileViewedHistory);
            _dbContext.SaveChanges();
            return clientProfileViewedHistory;
        }

        public bool DeleteClientProfileViewedHistory(long id)
        {
            var success = false;
            var result = _dbContext.ClientProfileViewedHistorys.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.ClientProfileViewedHistorys.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<ClientProfileViewedHistory> GetAllClientProfileViewedHistory(long clientId)
        {
            return _dbContext.ClientProfileViewedHistorys.Where(x=>x.client_id==clientId).ToList();
        }

        public ClientProfileViewedHistory GetClientProfileViewedHistoryById(long id)
        {
            var row = _dbContext.ClientProfileViewedHistorys.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }

        public ClientProfileViewedHistory UpdateClientProfileViewedHistory(ClientProfileViewedHistory clientProfileViewedHistory)
        {
            _dbContext.SaveChanges();
            return clientProfileViewedHistory;
        }
    }
}
