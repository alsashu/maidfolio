using MFMS.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IMaidReviewService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches MaidReview details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MaidReview object</returns>
        DTOMaidReview GetMaidReviewById(long id);

        /// <summary>
        /// Fetches all the MaidReview.
        /// </summary>
        /// <returns>IEnumerable<MaidReview></returns>
        IEnumerable<DTOMaidReview> GetAllMaidReview();

        /// <summary>
        /// Creates a MaidReview
        /// </summary>
        /// <param name="maidReview"></param>
        /// <returns>string invoice number</returns>
        DTOMaidReview AddMaidReview(DTOMaidReview maidReview);

        /// <summary>
        /// Updates a MaidReview
        /// </summary>
        /// <param name="maidReview"></param>
        /// <returns>bool</returns>
        DTOMaidReview UpdateMaidReview(DTOMaidReview maidReview);

        /// <summary>
        /// Delete a particular MaidReview
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteMaidReview(long id);
        
        #endregion
    }
}
