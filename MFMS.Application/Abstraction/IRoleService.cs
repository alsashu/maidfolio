using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IRoleService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches Role details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Role object</returns>
        DTORole GetRoleById(int id);

        /// <summary>
        /// Fetches all the Role.
        /// </summary>
        /// <returns>IEnumerable<Role></returns>
        IEnumerable<DTORole> GetAllRole();

        /// <summary>
        /// Creates a Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns>string invoice number</returns>
        DTORole AddRole(DTORole role);

        /// <summary>
        /// Updates a Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns>bool</returns>
        DTORole UpdateRole(DTORole role);

        /// <summary>
        /// Delete a particular Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteRole(int id);

        #endregion
    }
}
