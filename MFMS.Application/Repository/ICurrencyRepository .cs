using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface ICurrencyRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Currency details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Currency object</returns>
        Currency GetCurrencyById(int id);

        /// <summary>
        /// Fetches Currency details by id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>Currency object</returns>
        Currency GetCurrencyByCountryId(int countryId);

        /// <summary>
        /// Fetches all the Currency.
        /// </summary>
        /// <returns>IEnumerable<Currency></returns>
        IEnumerable<Currency> GetAllCurrency();

        /// <summary>
        /// Creates a Currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns>string invoice number</returns>
        Currency AddCurrency(Currency currency);

        /// <summary>
        /// Updates a Currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns>bool</returns>
        Currency UpdateCurrency(Currency currency);

        /// <summary>
        /// Delete a particular Currency
        /// Deactive a particular Currency
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteCurrency(int id);

        #endregion
    }
}
