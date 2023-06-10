using MFMS.DataTransferObject;

namespace MFMS.Application.Abstraction
{
    
    public interface IClientService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches client details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>client object</returns>
        DTOClient GetClientById(long id);

        /// <summary>
        /// Fetches all the client.
        /// </summary>
        /// <returns>IEnumerable<client></returns>
        IEnumerable<DTOClient> GetAllClient();

        /// <summary>
        /// Creates a client
        /// </summary>
        /// <param name="client"></param>
        /// <returns>string invoice number</returns>
        DTOClient AddClient(DTOClient client);

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="client"></param>
        /// <returns>bool</returns>
        DTOClient UpdateClient(DTOClient client);

        /// <summary>
        /// Delete a particular client
        /// Deactive a particular client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteClient(long id);
        /// <summary>
        /// Fetches client details by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of client object</returns>
        #endregion
    }
}