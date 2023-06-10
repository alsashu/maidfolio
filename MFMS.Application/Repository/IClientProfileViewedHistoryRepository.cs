using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IClientProfileViewedHistoryRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches ClientProfileViewedHistory details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientProfileViewedHistory object</returns>
        ClientProfileViewedHistory GetClientProfileViewedHistoryById(long id);

        /// <summary>
        /// Fetches all the ClientProfileViewedHistory.
        /// </summary>
        /// <returns>IEnumerable<ClientProfileViewedHistory></returns>
        IEnumerable<ClientProfileViewedHistory> GetAllClientProfileViewedHistory(long clientId);

        /// <summary>
        /// Creates a ClientProfileViewedHistory
        /// </summary>
        /// <param name="clientProfileViewedHistory"></param>
        /// <returns>string invoice number</returns>
        ClientProfileViewedHistory AddClientProfileViewedHistory(ClientProfileViewedHistory clientProfileViewedHistory);

        /// <summary>
        /// Updates a ClientProfileViewedHistory
        /// </summary>
        /// <param name="clientProfileViewedHistory"></param>
        /// <returns>bool</returns>
        ClientProfileViewedHistory UpdateClientProfileViewedHistory(ClientProfileViewedHistory clientProfileViewedHistory);

        /// <summary>
        /// Delete a particular ClientProfileViewedHistory
        /// Deactive a particular ClientProfileViewedHistory
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteClientProfileViewedHistory(long id);

        #endregion
    }
}
