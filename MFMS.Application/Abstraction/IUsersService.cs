using MFMS.DataTransferObject;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{

    /// <summary>
    /// Users Service Contract
    /// </summary>
    public interface IUsersService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Users details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Users object</returns>
        DTOUsers GetById(int id);

        /// <summary>
        /// Fetches all the Users.
        /// </summary>
        /// <returns>IEnumerable<Users></returns>
        IEnumerable<DTOUsers> GetAll();

        /// <summary>
        /// Creates a Users
        /// </summary>
        /// <param name="Users"></param>
        /// <returns>string invoice number</returns>
        DTOUsers Add(DTOUsers Users);

        /// <summary>
        /// Updates a Users
        /// </summary>
        /// <param name="Users"></param>
        /// <returns>bool</returns>
        DTOUsers Update(DTOUsers Users);

        /// <summary>
        /// Delete a particular Users
        /// Deactive a particular Users
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// Fetches Users details by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Users object</returns>
        #endregion
    }

}
