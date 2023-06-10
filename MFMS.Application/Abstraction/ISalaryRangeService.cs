using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface ISalaryRangeService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches SalaryRange details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SalaryRange object</returns>
        DTOSalaryRange GetSalaryRangeById(int id);

        /// <summary>
        /// Fetches all the SalaryRange.
        /// </summary>
        /// <returns>IEnumerable<SalaryRange></returns>
        IEnumerable<DTOSalaryRange> GetAllSalaryRange();

        /// <summary>
        /// Creates a SalaryRange
        /// </summary>
        /// <param name="salaryRange"></param>
        /// <returns>string invoice number</returns>
        DTOSalaryRange AddSalaryRange(DTOSalaryRange salaryRange);

        /// <summary>
        /// Updates a SalaryRange
        /// </summary>
        /// <param name="salaryRange"></param>
        /// <returns>bool</returns>
        DTOSalaryRange UpdateSalaryRange(DTOSalaryRange salaryRange);

        /// <summary>
        /// Delete a particular SalaryRange
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteSalaryRange(int id);

        #endregion
    }
}
