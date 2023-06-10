using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IStateService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches State details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>State object</returns>
        DTOState GetStateById(int id);

        /// <summary>
        /// Fetches all the State.
        /// </summary>
        /// <returns>IEnumerable<State></returns>
        IEnumerable<DTOState> GetAllState();

        /// <summary>
        /// Fetches all the State by countryId.
        /// </summary>
        /// /// <param name="countryId"></param>
        /// <returns>IEnumerable<State></returns>
        IEnumerable<DTOState> GetAllStateByCountry(int countryId);

        /// <summary>
        /// Creates a State
        /// </summary>
        /// <param name="state"></param>
        /// <returns>string invoice number</returns>
        DTOState AddState(DTOState state);

        /// <summary>
        /// Updates a State
        /// </summary>
        /// <param name="state"></param>
        /// <returns>bool</returns>
        DTOState UpdateState(DTOState state);

        /// <summary>
        /// Delete a particular State
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteState(int id);

        #endregion
    }
}
