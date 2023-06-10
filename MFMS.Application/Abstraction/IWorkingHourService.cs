using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IWorkingHourService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches WorkingHour details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>WorkingHour object</returns>
        DTOWorkingHour GetWorkingHourById(int id);

        /// <summary>
        /// Fetches all the WorkingHour.
        /// </summary>
        /// <returns>IEnumerable<WorkingHour></returns>
        IEnumerable<DTOWorkingHour> GetAllWorkingHour();

        /// <summary>
        /// Creates a WorkingHour
        /// </summary>
        /// <param name="workingHour"></param>
        /// <returns>string invoice number</returns>
        DTOWorkingHour AddWorkingHour(DTOWorkingHour workingHour);

        /// <summary>
        /// Updates a WorkingHour
        /// </summary>
        /// <param name="workingHour"></param>
        /// <returns>bool</returns>
        DTOWorkingHour UpdateWorkingHour(DTOWorkingHour workingHour);

        /// <summary>
        /// Delete a particular WorkingHour
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteWorkingHour(int id);

        #endregion
    }
}
