using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class DocumentTypeRepository: IDocumentTypeRepository
    {
        public EF_DbContext _dbContext;

        public DocumentTypeRepository(EF_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DocumentType AddDocumentType(DocumentType documentType)
        {
            _dbContext.Add(documentType);
            _dbContext.SaveChanges();
            return documentType;
        }

        public bool DeleteDocumentType(int id)
        {
            var success = false;
            var result = _dbContext.DocumentTypes.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                _dbContext.DocumentTypes.Remove(result);
                _dbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public IEnumerable<DocumentType> GetAllDocumentType()
        {
            return _dbContext.DocumentTypes.ToList();
        }

        public DocumentType GetDocumentTypeById(int id)
        {
            var row = _dbContext.DocumentTypes.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return row;
            }
            return null;
        }
        public DocumentType UpdateDocumentType(DocumentType documentType)
        {
            _dbContext.SaveChanges();
            return documentType;
        }
    }
}
