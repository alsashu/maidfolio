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
    public class RoleMasterService : IRoleMasterService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IRoleMasterRepository _roleMasterRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public RoleMasterService(IRoleMasterRepository roleMasterRepository)
        {
            _roleMasterRepository = roleMasterRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoleMaster, DTORoleMaster>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description))
                    .ForMember(dest => dest.is_active, opt => opt.MapFrom(src => src.is_active));
            });
        }
        #endregion

        #region Public member methods.
        public DTORoleMaster AddRoleMaster(DTORoleMaster roleMaster)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            RoleMaster roleMasters = new RoleMaster
            {
                name = roleMaster.name,
                description = roleMaster.description,
                is_active = roleMaster.is_active,
            };
            var data = _roleMasterRepository.AddRoleMaster(roleMasters);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<RoleMaster, DTORoleMaster>(data);
                return result;
            }
            return null;
        }

        public bool DeleteRoleMaster(int id)
        {
            bool result = _roleMasterRepository.DeleteRoleMaster(id);
            return result;
        }

        public IEnumerable<DTORoleMaster> GetAllRoleMaster()
        {
            var data = _roleMasterRepository.GetAllRoleMaster();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<RoleMaster>, IEnumerable<DTORoleMaster>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTORoleMaster>();
        }

        public DTORoleMaster GetRoleMasterById(int id)
        {
            var data = _roleMasterRepository.GetRoleMasterById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<RoleMaster, DTORoleMaster>(data);
                return result;
            }
            return null;

        }
        public DTORoleMaster UpdateRoleMaster(DTORoleMaster roleMaster)
        {
            var data = _roleMasterRepository.GetRoleMasterById(roleMaster.id);
            data.name = roleMaster.name;
            data.description = roleMaster.description;
            data.is_active = roleMaster.is_active;
            data = _roleMasterRepository.UpdateRoleMaster(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<RoleMaster, DTORoleMaster>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
