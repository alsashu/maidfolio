using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IRoleMasterRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches RoleMaster details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RoleMaster object</returns>
        RoleMaster GetRoleMasterById(int id);

        /// <summary>
        /// Fetches all the RoleMaster.
        /// </summary>
        /// <returns>IEnumerable<RoleMaster></returns>
        IEnumerable<RoleMaster> GetAllRoleMaster();

        /// <summary>
        /// Creates a RoleMaster
        /// </summary>
        /// <param name="roleMaster"></param>
        /// <returns>string invoice number</returns>
        RoleMaster AddRoleMaster(RoleMaster roleMaster);

        /// <summary>
        /// Updates a RoleMaster
        /// </summary>
        /// <param name="roleMaster"></param>
        /// <returns>bool</returns>
        RoleMaster UpdateRoleMaster(RoleMaster roleMaster);

        /// <summary>
        /// Delete a particular RoleMaster
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteRoleMaster(int id);

        #endregion
    }
}
