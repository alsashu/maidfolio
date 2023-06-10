using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IRequirementRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Requirement details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Requirement object</returns>
        Requirement GetRequirementById(long id);

        /// <summary>
        /// Fetches all the Requirement.
        /// </summary>
        /// <returns>IEnumerable<Requirement></returns>
        IEnumerable<Requirement> GetAllRequirement();

        /// <summary>
        /// Creates a Requirement
        /// </summary>
        /// <param name="requirement"></param>
        /// <returns>string invoice number</returns>
        Requirement AddRequirement(Requirement requirement);

        /// <summary>
        /// Updates a Requirement
        /// </summary>
        /// <param name="requirement"></param>
        /// <returns>bool</returns>
        Requirement UpdateRequirement(Requirement requirement);

        /// <summary>
        /// Delete a particular Requirement
        /// Deactive a particular Requirement
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteRequirement(long id);

        #endregion
    }
}
