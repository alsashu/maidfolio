using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IMaidReviewRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches MaidReview details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MaidReview object</returns>
        MaidReview GetMaidReviewById(long id);

        /// <summary>
        /// Fetches all the MaidReview.
        /// </summary>
        /// <returns>IEnumerable<MaidReview></returns>
        IEnumerable<MaidReview> GetAllMaidReview();

        /// <summary>
        /// Creates a MaidReview
        /// </summary>
        /// <param name="maidReview"></param>
        /// <returns>string invoice number</returns>
        MaidReview AddMaidReview(MaidReview maidReview);

        /// <summary>
        /// Updates a MaidReview
        /// </summary>
        /// <param name="maidReview"></param>
        /// <returns>bool</returns>
        MaidReview UpdateMaidReview(MaidReview maidReview);

        /// <summary>
        /// Delete a particular MaidReview
        /// Deactive a particular MaidReview
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteMaidReview(long id);

        #endregion
    }
}
