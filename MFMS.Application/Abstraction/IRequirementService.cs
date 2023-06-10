using MFMS.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IRequirementService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Requirement details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Requirement object</returns>
        DTORequirement GetRequirementById(long id);

        /// <summary>
        /// Fetches all the Requirement.
        /// </summary>
        /// <returns>IEnumerable<Requirement></returns>
        IEnumerable<DTORequirement> GetAllRequirement();

        /// <summary>
        /// Creates a Requirement
        /// </summary>
        /// <param name="requirement"></param>
        /// <returns>string invoice number</returns>
        DTORequirement AddRequirement(DTORequirement requirement);

        /// <summary>
        /// Updates a Requirement
        /// </summary>
        /// <param name="requirement"></param>
        /// <returns>bool</returns>
        DTORequirement UpdateRequirement(DTORequirement requirement);

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
