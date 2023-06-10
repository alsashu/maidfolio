using MFMS.Application.Repository;
using MFMS.Domain;

namespace MFMS.Infrastructure
{
    public class ClientRepository: IClientRepository
    {
        public EF_DbContext _dbContext;

        public ClientRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Client AddClient(Client client)
        {
            _dbContext.Add(client);
            _dbContext.SaveChanges();
            return client;
        }

        public bool DeleteClient(int id)
        {
            var success = false;
            var result = _dbContext.Clients.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.Clients.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public bool DeleteClient(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAllClient()
        {
            return _dbContext.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            var row = _dbContext.Clients.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }

        public Client GetClientById(long id)
        {
            throw new NotImplementedException();
        }

        public Client UpdateClient(Client client)
        {
            _dbContext.SaveChanges();
            return client;
        }
    }
}
