using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface ISubscriptionTypeService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches SubscriptionType details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SubscriptionType object</returns>
        DTOSubscriptionType GetSubscriptionTypeById(int id);

        /// <summary>
        /// Fetches all the SubscriptionType.
        /// </summary>
        /// <returns>IEnumerable<SubscriptionType></returns>
        IEnumerable<DTOSubscriptionType> GetAllSubscriptionType();

        /// <summary>
        /// Creates a SubscriptionType
        /// </summary>
        /// <param name="subscriptionType"></param>
        /// <returns>string invoice number</returns>
        DTOSubscriptionType AddSubscriptionType(DTOSubscriptionType subscriptionType);

        /// <summary>
        /// Updates a SubscriptionType
        /// </summary>
        /// <param name="subscriptionType"></param>
        /// <returns>bool</returns>
        DTOSubscriptionType UpdateSubscriptionType(DTOSubscriptionType subscriptionType);

        /// <summary>
        /// Delete a particular SubscriptionType
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteSubscriptionType(int id);

        #endregion
    }
}
