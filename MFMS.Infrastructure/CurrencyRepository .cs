using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class CurrencyRepository: ICurrencyRepository
    {
        public EF_DbContext _dbContext;

        public CurrencyRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Currency AddCurrency(Currency currency)
        {
            _dbContext.Add(currency);
            _dbContext.SaveChanges();
            return currency;
        }

        public bool DeleteCurrency(int id)
        {
            var success = false;
            var result = _dbContext.Currencys.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.Currencys.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<Currency> GetAllCurrency()
        {
            return _dbContext.Currencys.ToList();
        }

        public Currency GetCurrencyById(int id)
        {
            var row = _dbContext.Currencys.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public Currency GetCurrencyByCountryId(int countryId)
        {
            var row = _dbContext.Currencys.Where(t => t.country_id.Equals(countryId)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public Currency UpdateCurrency(Currency currency)
        {
            _dbContext.SaveChanges();
            return currency;
        }
    }
}
