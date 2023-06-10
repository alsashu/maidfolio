using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Abstraction
{
    public interface IDocumentTypeService
    {
        #region Interface member methods.

        /// <summary>
        /// Fetches DocumentType details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DocumentType object</returns>
        DTODocumentType GetDocumentTypeById(int id);

        /// <summary>
        /// Fetches all the DocumentType.
        /// </summary>
        /// <returns>IEnumerable<DocumentType></returns>
        IEnumerable<DTODocumentType> GetAllDocumentType();

        /// <summary>
        /// Creates a DocumentType
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns>string invoice number</returns>
        DTODocumentType AddDocumentType(DTODocumentType documentType);

        /// <summary>
        /// Updates a DocumentType
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns>bool</returns>
        DTODocumentType UpdateDocumentType(DTODocumentType documentType);

        /// <summary>
        /// Delete a particular DocumentType
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        bool DeleteDocumentType(int id);

        #endregion
    }
}
