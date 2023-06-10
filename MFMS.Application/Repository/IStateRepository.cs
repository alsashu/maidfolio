using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IStateRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches State details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>State object</returns>
        State GetStateById(int id);

        /// <summary>
        /// Fetches all the State.
        /// </summary>
        /// <returns>IEnumerable<State></returns>
        IEnumerable<State> GetAllState();

        /// <summary>
        /// Fetches all the State by countryId.
        /// </summary>
        /// /// <param name="countryId"></param>
        /// <returns>IEnumerable<State></returns>
        IEnumerable<State> GetAllStateByCountry(int countryId);

        /// <summary>
        /// Creates a State
        /// </summary>
        /// <param name="state"></param>
        /// <returns>string invoice number</returns>
        State AddState(State state);

        /// <summary>
        /// Updates a State
        /// </summary>
        /// <param name="state"></param>
        /// <returns>bool</returns>
        State UpdateState(State state);

        /// <summary>
        /// Delete a particular State
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteState(int id);

        #endregion
    }
}
