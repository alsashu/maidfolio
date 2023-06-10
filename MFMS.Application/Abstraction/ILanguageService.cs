using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface ILanguageService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Language details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Language object</returns>
        DTOLanguage GetLanguageById(int id);

        /// <summary>
        /// Fetches all the Language.
        /// </summary>
        /// <returns>IEnumerable<Language></returns>
        IEnumerable<DTOLanguage> GetAllLanguage();

        /// <summary>
        /// Fetches all the Language.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>IEnumerable<Language></returns>
        IEnumerable<DTOLanguage> GetAllLanguageByCountryId(int countryId);

        /// <summary>
        /// Creates a Language
        /// </summary>
        /// <param name="language"></param>
        /// <returns>string invoice number</returns>
        DTOLanguage AddLanguage(DTOLanguage language);

        /// <summary>
        /// Updates a Language
        /// </summary>
        /// <param name="language"></param>
        /// <returns>bool</returns>
        DTOLanguage UpdateLanguage(DTOLanguage language);

        /// <summary>
        /// Delete a particular Language
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteLanguage(int id);

        #endregion
    }
}
