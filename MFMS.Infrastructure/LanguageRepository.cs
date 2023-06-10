using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class LanguageRepository: ILanguageRepository
    {
        public EF_DbContext _dbContext;

        public LanguageRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Language AddLanguage(Language language)
        {
            _dbContext.Add(language);
            _dbContext.SaveChanges();
            return language;
        }

        public bool DeleteLanguage(int id)
        {
            var success = false;
            var result = _dbContext.Languages.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.Languages.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<Language> GetAllLanguage()
        {
            return _dbContext.Languages.ToList();
        }

        public IEnumerable<Language> GetAllLanguageByCountryId(int countryId)
        {
            return _dbContext.Languages.Where(x=>x.country_id.Equals(countryId)).ToList();
        }
        public Language GetLanguageById(int id)
        {
            var row = _dbContext.Languages.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public Language UpdateLanguage(Language language)
        {
            _dbContext.SaveChanges();
            return language;
        }
    }
}
