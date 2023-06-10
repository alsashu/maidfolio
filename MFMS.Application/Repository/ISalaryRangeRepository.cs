using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface ISalaryRangeRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches SalaryRange details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SalaryRange object</returns>
        SalaryRange GetSalaryRangeById(int id);

        /// <summary>
        /// Fetches all the SalaryRange.
        /// </summary>
        /// <returns>IEnumerable<SalaryRange></returns>
        IEnumerable<SalaryRange> GetAllSalaryRange();

        /// <summary>
        /// Creates a SalaryRange
        /// </summary>
        /// <param name="salaryRange"></param>
        /// <returns>string invoice number</returns>
        SalaryRange AddSalaryRange(SalaryRange salaryRange);

        /// <summary>
        /// Updates a SalaryRange
        /// </summary>
        /// <param name="salaryRange"></param>
        /// <returns>bool</returns>
        SalaryRange UpdateSalaryRange(SalaryRange salaryRange);

        /// <summary>
        /// Delete a particular SalaryRange
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteSalaryRange(int id);

        #endregion
    }
}
