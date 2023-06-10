using MFMS.DataTransferObject;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{  
    public interface IClientProfileViewedHistoryService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches ClientProfileViewedHistory details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientProfileViewedHistory object</returns>
        DTOClientProfileViewedHistory GetClientProfileViewedHistoryById(long id);

        /// <summary>
        /// Fetches all the ClientProfileViewedHistory.
        /// </summary>
        /// <returns>IEnumerable<ClientProfileViewedHistory></returns>
        IEnumerable<DTOClientProfileViewedHistory> GetAllClientProfileViewedHistory(long clientId);

        /// <summary>
        /// Creates a ClientProfileViewedHistory
        /// </summary>
        /// <param name="clientProfileViewedHistory"></param>
        /// <returns>string invoice number</returns>
        DTOClientProfileViewedHistory AddClientProfileViewedHistory(DTOClientProfileViewedHistory clientProfileViewedHistory);

        /// <summary>
        /// Updates a ClientProfileViewedHistory
        /// </summary>
        /// <param name="clientProfileViewedHistory"></param>
        /// <returns>bool</returns>
        DTOClientProfileViewedHistory UpdateClientProfileViewedHistory(DTOClientProfileViewedHistory clientProfileViewedHistory);

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
