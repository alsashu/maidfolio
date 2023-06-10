using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IClientRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Client details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Client object</returns>
        Client GetClientById(long id);

        /// <summary>
        /// Fetches all the Client.
        /// </summary>
        /// <returns>IEnumerable<Client></returns>
        IEnumerable<Client> GetAllClient();

        /// <summary>
        /// Creates a Client
        /// </summary>
        /// <param name="Client"></param>
        /// <returns>string invoice number</returns>
        Client AddClient(Client client);

        /// <summary>
        /// Updates a Client
        /// </summary>
        /// <param name="Client"></param>
        /// <returns>bool</returns>
        Client UpdateClient(Client client);

        /// <summary>
        /// Delete a particular Client
        /// Deactive a particular Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteClient(long id);

        #endregion
    }
}
