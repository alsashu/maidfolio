using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IRoleMasterService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches RoleMaster details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RoleMaster object</returns>
        DTORoleMaster GetRoleMasterById(int id);

        /// <summary>
        /// Fetches all the RoleMaster.
        /// </summary>
        /// <returns>IEnumerable<RoleMaster></returns>
        IEnumerable<DTORoleMaster> GetAllRoleMaster();

        /// <summary>
        /// Creates a RoleMaster
        /// </summary>
        /// <param name="roleMaster"></param>
        /// <returns>string invoice number</returns>
        DTORoleMaster AddRoleMaster(DTORoleMaster roleMaster);

        /// <summary>
        /// Updates a RoleMaster
        /// </summary>
        /// <param name="roleMaster"></param>
        /// <returns>bool</returns>
        DTORoleMaster UpdateRoleMaster(DTORoleMaster roleMaster);

        /// <summary>
        /// Delete a particular RoleMaster
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteRoleMaster(int id);

        #endregion
    }
}
