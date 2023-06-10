using MFMS.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IMaidService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches maid details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>maid object</returns>
        DTOMaid GetById(int id);

        /// <summary>
        /// Fetches all the maid.
        /// </summary>
        /// <returns>IEnumerable<maid></returns>
        IEnumerable<DTOMaid> GetAll();

        /// <summary>
        /// Creates a maid
        /// </summary>
        /// <param name="maid"></param>
        /// <returns>string invoice number</returns>
        DTOMaid Add(DTOMaid maid);

        /// <summary>
        /// Updates a maid
        /// </summary>
        /// <param name="maid"></param>
        /// <returns>bool</returns>
        DTOMaid Update(DTOMaid maid);

        /// <summary>
        /// Delete a particular maid
        /// Deactive a particular maid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool Delete(int id);
        /// <summary>
        /// Fetches maid details by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of maid object</returns>
        #endregion
    }
}
