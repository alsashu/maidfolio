using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Repository
{
    public interface IDocumentTypeRepository
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches DocumentType details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DocumentType object</returns>
        DocumentType GetDocumentTypeById(int id);

        /// <summary>
        /// Fetches all the DocumentType.
        /// </summary>
        /// <returns>IEnumerable<DocumentType></returns>
        IEnumerable<DocumentType> GetAllDocumentType();

        /// <summary>
        /// Creates a DocumentType
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns>string invoice number</returns>
        DocumentType AddDocumentType(DocumentType documentType);

        /// <summary>
        /// Updates a DocumentType
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns>bool</returns>
        DocumentType UpdateDocumentType(DocumentType documentType);

        /// <summary>
        /// Delete a particular DocumentType
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteDocumentType(int id);

        #endregion
    }
}
