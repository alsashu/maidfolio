using AutoMapper;
using MFMS.Application.Abstraction;
using MFMS.Application.Repository;
using MFMS.DataTransferObject;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Implementation
{
    public class RequirementService : IRequirementService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IRequirementRepository _requirementRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public RequirementService(IRequirementRepository requirementRepository)
        {
            _requirementRepository = requirementRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Requirement, DTORequirement>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.contact_number, opt => opt.MapFrom(src => src.contact_number))
                    .ForMember(dest => dest.requirements, opt => opt.MapFrom(src => src.requirements))
                    .ForMember(dest => dest.comments_by_admin, opt => opt.MapFrom(src => src.comments_by_admin))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
                    .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.created_by))
                    .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => src.created_date))
                    .ForMember(dest => dest.modified_by, opt => opt.MapFrom(src => src.modified_by))
                    .ForMember(dest => dest.modified_date, opt => opt.MapFrom(src => src.modified_date));
            });
        }
        #endregion

        #region Public member methods.
        public DTORequirement AddRequirement(DTORequirement requirement)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            Requirement requirements = new Requirement
            {
                name = requirement.name,
                contact_number = requirement.contact_number,
                requirements = requirement.requirements,
                comments_by_admin = requirement.comments_by_admin,
                status = requirement.status,
                created_by = requirement.created_by,
                created_date = requirement.created_date,
                modified_by = requirement.modified_by,
                modified_date = requirement.modified_date,
            };
            var data = _requirementRepository.AddRequirement(requirements);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Requirement, DTORequirement>(data);
                return result;
            }
            return null;
        }

        public bool DeleteRequirement(long id)
        {
            bool result = _requirementRepository.DeleteRequirement(id);
            return result;
        }

        public IEnumerable<DTORequirement> GetAllRequirement()
        {
            var data = _requirementRepository.GetAllRequirement();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<Requirement>, IEnumerable<DTORequirement>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTORequirement>();
        }

        public DTORequirement GetRequirementById(long id)
        {
            var data = _requirementRepository.GetRequirementById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Requirement, DTORequirement>(data);
                return result;
            }
            return null;

        }
        public DTORequirement UpdateRequirement(DTORequirement requirement)
        {
            var data = _requirementRepository.GetRequirementById(requirement.id);
            data.name = requirement.name;
            data.contact_number = requirement.contact_number;
            data.requirements = requirement.requirements;
            data.comments_by_admin = requirement.comments_by_admin;
            data.status = requirement.status;
            data.created_by = requirement.created_by;
            data.created_date = requirement.created_date;
            data.modified_by = requirement.modified_by;
            data.modified_date = requirement.modified_date;
            data = _requirementRepository.UpdateRequirement(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Requirement, DTORequirement>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
