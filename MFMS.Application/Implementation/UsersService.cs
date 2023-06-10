using AutoMapper;
using MFMS.Application.Abstraction;
using MFMS.Application.DomainLogics;
using MFMS.Application.Repository;
using MFMS.DataTransferObject;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Implementation
{
    public class UsersService : IUsersService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IUsersRepository _usersRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, DTOUsers>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                    .ForMember(dest => dest.country_code, opt => opt.MapFrom(src => src.country_code))
                    .ForMember(dest => dest.mobile, opt => opt.MapFrom(src => src.mobile))
                    .ForMember(dest => dest.created_on, opt => opt.MapFrom(src => src.created_on))
                    .ForMember(dest => dest.active, opt => opt.MapFrom(src => src.active))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name));
            });
        }
        #endregion

        #region Public member methods.
        public DTOUsers Add(DTOUsers user)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;


            Users users = new Users
            {
                email = user.email,
                name = user.name,
                is_deleted = false,
                password = user.password,
                role_id = 0,
                created_on = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                updated_date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                active=true
            };
            var data = _usersRepository.Add(users);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Users, DTOUsers>(data);
                return result;
            }
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTOUsers> GetAll()
        {
            var data = _usersRepository.GetAll();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<Users>, IEnumerable<DTOUsers>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOUsers>();
        }

        public DTOUsers GetById(int id)
        {
            var data = _usersRepository.GetById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Users, DTOUsers>(data);
                return result;
            }
            return null;

        }


        public DTOUsers Update(DTOUsers Users)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
