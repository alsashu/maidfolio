using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class CountryRepository: ICountryRepository
    {
        public EF_DbContext _dbContext;

        public CountryRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Country AddCountry(Country country)
        {
            _dbContext.Add(country);
            _dbContext.SaveChanges();
            return country;
        }

        public bool DeleteCountry(int id)
        {
            var success = false;
            var result = _dbContext.Countrys.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.Countrys.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<Country> GetAllCountry()
        {
            return _dbContext.Countrys.ToList();
        }

        public Country GetCountryById(int id)
        {
            var row = _dbContext.Countrys.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public Country UpdateCountry(Country country)
        {
            _dbContext.SaveChanges();
            return country;
        }
    }
}
