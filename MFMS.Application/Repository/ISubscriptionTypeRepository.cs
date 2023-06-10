using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface ISubscriptionTypeRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches SubscriptionType details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SubscriptionType object</returns>
        SubscriptionType GetSubscriptionTypeById(int id);

        /// <summary>
        /// Fetches all the SubscriptionType.
        /// </summary>
        /// <returns>IEnumerable<SubscriptionType></returns>
        IEnumerable<SubscriptionType> GetAllSubscriptionType();

        /// <summary>
        /// Creates a SubscriptionType
        /// </summary>
        /// <param name="subscriptionType"></param>
        /// <returns>string invoice number</returns>
        SubscriptionType AddSubscriptionType(SubscriptionType subscriptionType);

        /// <summary>
        /// Updates a SubscriptionType
        /// </summary>
        /// <param name="subscriptionType"></param>
        /// <returns>bool</returns>
        SubscriptionType UpdateSubscriptionType(SubscriptionType subscriptionType);

        /// <summary>
        /// Delete a particular SubscriptionType
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteSubscriptionType(int id);

        #endregion
    }
}
