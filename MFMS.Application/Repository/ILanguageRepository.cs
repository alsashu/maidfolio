using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface ILanguageRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Language details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Language object</returns>
        Language GetLanguageById(int id);

        /// <summary>
        /// Fetches all the Language.
        /// </summary>
        /// <returns>IEnumerable<Language></returns>
        IEnumerable<Language> GetAllLanguage();

        /// <summary>
        /// Fetches all the Language.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>IEnumerable<Language></returns>
        IEnumerable<Language> GetAllLanguageByCountryId(int countryId);

        /// <summary>
        /// Creates a Language
        /// </summary>
        /// <param name="language"></param>
        /// <returns>string invoice number</returns>
        Language AddLanguage(Language language);

        /// <summary>
        /// Updates a Language
        /// </summary>
        /// <param name="language"></param>
        /// <returns>bool</returns>
        Language UpdateLanguage(Language language);

        /// <summary>
        /// Delete a particular Language
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteLanguage(int id);

        #endregion
    }
}
