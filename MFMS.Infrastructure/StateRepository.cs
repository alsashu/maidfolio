using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class StateRepository: IStateRepository
    {
        public EF_DbContext _dbContext;

        public StateRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public State AddState(State state)
        {
            _dbContext.Add(state);
            _dbContext.SaveChanges();
            return state;
        }

        public bool DeleteState(int id)
        {
            var success = false;
            var result = _dbContext.States.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.States.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<State> GetAllState()
        {
            return _dbContext.States.ToList();
        }

        public IEnumerable<State> GetAllStateByCountry(int countryId)
        {
            return _dbContext.States.Where(t => t.country_id.Equals(countryId)).ToList();
        }

        public State GetStateById(int id)
        {
            var row = _dbContext.States.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public State UpdateState(State state)
        {
            _dbContext.SaveChanges();
            return state;
        }
    }
}
