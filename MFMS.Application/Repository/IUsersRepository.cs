using MFMS.DataTransferObject;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    /// <summary>
    /// Users Service Contract
    /// </summary>
    public interface IUsersRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Users details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Users object</returns>
        Users GetById(int id);

        /// <summary>
        /// Fetches all the Users.
        /// </summary>
        /// <returns>IEnumerable<Users></returns>
        IEnumerable<Users> GetAll();

        /// <summary>
        /// Creates a Users
        /// </summary>
        /// <param name="Users"></param>
        /// <returns>string invoice number</returns>
        Users Add(Users Users);

        /// <summary>
        /// Updates a Users
        /// </summary>
        /// <param name="Users"></param>
        /// <returns>bool</returns>
        Users Update(Users Users);

        /// <summary>
        /// Delete a particular Users
        /// Deactive a particular Users
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool Delete(int id);
        
        #endregion

    }
}
