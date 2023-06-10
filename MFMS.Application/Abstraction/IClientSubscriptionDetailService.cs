using MFMS.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IClientSubscriptionDetailService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches ClientSubscriptionDetail details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientSubscriptionDetail object</returns>
        DTOClientSubscriptionDetail GetClientSubscriptionDetailById(long id);

        /// <summary>
        /// Fetches all the ClientSubscriptionDetail.
        /// </summary>
        /// <returns>IEnumerable<ClientSubscriptionDetail></returns>
        IEnumerable<DTOClientSubscriptionDetail> GetClientSubscriptionDetailByClientId(long clientId);

        /// <summary>
        /// Fetches all the GetAllClientSubscriptionDetail.
        /// </summary>
        /// <returns>IEnumerable<GetAllClientSubscriptionDetail></returns>
        IEnumerable<DTOClientSubscriptionDetail> GetAllClientSubscriptionDetail();

        /// <summary>
        /// Creates a ClientSubscriptionDetail
        /// </summary>
        /// <param name="clientSubscriptionDetail"></param>
        /// <returns>string invoice number</returns>
        DTOClientSubscriptionDetail AddClientSubscriptionDetail(DTOClientSubscriptionDetail clientSubscriptionDetail);

        /// <summary>
        /// Updates a ClientSubscriptionDetail
        /// </summary>
        /// <param name="clientSubscriptionDetail"></param>
        /// <returns>bool</returns>
        DTOClientSubscriptionDetail UpdateClientSubscriptionDetail(DTOClientSubscriptionDetail clientSubscriptionDetail);

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
