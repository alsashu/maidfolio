using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface ICountryService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Country details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Country object</returns>
        DTOCountry GetCountryById(int id);

        /// <summary>
        /// Fetches all the Country.
        /// </summary>
        /// <returns>IEnumerable<Country></returns>
        IEnumerable<DTOCountry> GetAllCountry();

        /// <summary>
        /// Creates a Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns>string invoice number</returns>
        DTOCountry AddCountry(DTOCountry country);

        /// <summary>
        /// Updates a Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns>bool</returns>
        DTOCountry UpdateCountry(DTOCountry country);

        /// <summary>
        /// Delete a particular Country
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteCountry(int id);

        #endregion
    }
}
