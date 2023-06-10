using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IMaidRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Maid details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Maid object</returns>
        Maid GetById(int id);

        /// <summary>
        /// Fetches all the Maid.
        /// </summary>
        /// <returns>IEnumerable<Maid></returns>
        IEnumerable<Maid> GetAll();

        /// <summary>
        /// Creates a Maid
        /// </summary>
        /// <param name="Maid"></param>
        /// <returns>string invoice number</returns>
        Maid Add(Maid maid);

        /// <summary>
        /// Updates a Maid
        /// </summary>
        /// <param name="Maid"></param>
        /// <returns>bool</returns>
        Maid Update(Maid maid);

        /// <summary>
        /// Delete a particular Maid
        /// Deactive a particular Maid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool Delete(int id);
        
        #endregion
    }
}
