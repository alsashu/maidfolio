using AutoMapper;
using MFMS.Application.Abstraction;
using MFMS.Application.Repository;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Implementation
{
    public class DocumentTypeService : IDocumentTypeService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DocumentType, DTODocumentType>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.document_name, opt => opt.MapFrom(src => src.document_name))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status));
            });
        }
        #endregion

        #region Public member methods.
        public DTODocumentType AddDocumentType(DTODocumentType documentType)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            DocumentType documentTypes = new DocumentType
            {
                document_name = documentType.document_name,
                status = documentType.status,
            };
            var data = _documentTypeRepository.AddDocumentType(documentTypes);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<DocumentType, DTODocumentType>(data);
                return result;
            }
            return null;
        }

        public bool DeleteDocumentType(int id)
        {
            bool result = _documentTypeRepository.DeleteDocumentType(id);
            return result;
        }

        public IEnumerable<DTODocumentType> GetAllDocumentType()
        {
            var data = _documentTypeRepository.GetAllDocumentType();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<DocumentType>, IEnumerable<DTODocumentType>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTODocumentType>();
        }

        public DTODocumentType GetDocumentTypeById(int id)
        {
            var data = _documentTypeRepository.GetDocumentTypeById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<DocumentType, DTODocumentType>(data);
                return result;
            }
            return null;

        }
        public DTODocumentType UpdateDocumentType(DTODocumentType documentType)
        {
            var data = _documentTypeRepository.GetDocumentTypeById(documentType.id);
            data.document_name = documentType.document_name;
            data.status = documentType.status;
            data = _documentTypeRepository.UpdateDocumentType(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<DocumentType, DTODocumentType>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
