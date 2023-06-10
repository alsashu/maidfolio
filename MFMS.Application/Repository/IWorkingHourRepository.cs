using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IWorkingHourRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches WorkingHour details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>WorkingHour object</returns>
        WorkingHour GetWorkingHourById(int id);

        /// <summary>
        /// Fetches all the WorkingHour.
        /// </summary>
        /// <returns>IEnumerable<WorkingHour></returns>
        IEnumerable<WorkingHour> GetAllWorkingHour();

        /// <summary>
        /// Creates a WorkingHour
        /// </summary>
        /// <param name="workingHour"></param>
        /// <returns>string invoice number</returns>
        WorkingHour AddWorkingHour(WorkingHour workingHour);

        /// <summary>
        /// Updates a WorkingHour
        /// </summary>
        /// <param name="workingHour"></param>
        /// <returns>bool</returns>
        WorkingHour UpdateWorkingHour(WorkingHour workingHour);

        /// <summary>
        /// Delete a particular WorkingHour
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteWorkingHour(int id);

        #endregion
    }
}
