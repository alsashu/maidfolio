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
    public class RoleService : IRoleService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IRoleRepository _roleRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, DTORole>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.role_for, opt => opt.MapFrom(src => src.role_for))
                    .ForMember(dest => dest.role_name, opt => opt.MapFrom(src => src.role_name))
                    .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description))
                    .ForMember(dest => dest.active, opt => opt.MapFrom(src => src.active));
            });
        }
        #endregion

        #region Public member methods.
        public DTORole AddRole(DTORole role)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            Role roles = new Role
            {
                role_for = role.role_for,
                role_name = role.role_name,
                description = role.description,
                active = role.active,
            };
            var data = _roleRepository.AddRole(roles);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Role, DTORole>(data);
                return result;
            }
            return null;
        }

        public bool DeleteRole(int id)
        {
            bool result = _roleRepository.DeleteRole(id);
            return result;
        }

        public IEnumerable<DTORole> GetAllRole()
        {
            var data = _roleRepository.GetAllRole();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<Role>, IEnumerable<DTORole>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTORole>();
        }

        public DTORole GetRoleById(int id)
        {
            var data = _roleRepository.GetRoleById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Role, DTORole>(data);
                return result;
            }
            return null;

        }
        public DTORole UpdateRole(DTORole role)
        {
            var data = _roleRepository.GetRoleById(role.id);
            data.role_for = role.role_for;
            data.role_name = role.role_name;
            data.description = role.description;
            data = _roleRepository.UpdateRole(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Role, DTORole>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
