using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface ICountryRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Country details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Country object</returns>
        Country GetCountryById(int id);

        /// <summary>
        /// Fetches all the Country.
        /// </summary>
        /// <returns>IEnumerable<Country></returns>
        IEnumerable<Country> GetAllCountry();

        /// <summary>
        /// Creates a Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns>string invoice number</returns>
        Country AddCountry(Country country);

        /// <summary>
        /// Updates a Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns>bool</returns>
        Country UpdateCountry(Country country);

        /// <summary>
        /// Delete a particular Country
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteCountry(int id);

        #endregion
    }
}
