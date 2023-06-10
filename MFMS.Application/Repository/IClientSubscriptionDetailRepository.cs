using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IClientSubscriptionDetailRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches ClientSubscriptionDetail details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientSubscriptionDetail object</returns>
        ClientSubscriptionDetail GetClientSubscriptionDetailById(long id);

        /// <summary>
        /// Fetches ClientSubscriptionDetail details by client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns>ClientSubscriptionDetail object</returns>
        IEnumerable<ClientSubscriptionDetail> GetClientSubscriptionDetailByClientId(long clientId);

        /// <summary>
        /// Fetches all the ClientSubscriptionDetail.
        /// </summary>
        /// <returns>IEnumerable<ClientSubscriptionDetail></returns>
        IEnumerable<ClientSubscriptionDetail> GetAllClientSubscriptionDetail();

        /// <summary>
        /// Creates a ClientSubscriptionDetail
        /// </summary>
        /// <param name="clientSubscriptionDetail"></param>
        /// <returns>string invoice number</returns>
        ClientSubscriptionDetail AddClientSubscriptionDetail(ClientSubscriptionDetail clientSubscriptionDetail);

        /// <summary>
        /// Updates a ClientSubscriptionDetail
        /// </summary>
        /// <param name="clientSubscriptionDetail"></param>
        /// <returns>bool</returns>
        ClientSubscriptionDetail UpdateClientSubscriptionDetail(ClientSubscriptionDetail clientSubscriptionDetail);

        /// <summary>
        /// Delete a particular ClientSubscriptionDetail
        /// Deactive a particular ClientSubscriptionDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteClientSubscriptionDetail(long id);

        #endregion
    }
}
