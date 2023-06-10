using AutoMapper;
using MFMS.Application.Abstraction;
using MFMS.Application.Repository;
using MFMS.DataTransferObject;
using MFMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Application.Implementation
{
    public class ClientService : IClientService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IClientRepository _clientRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Client, DTOClient>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.first_name, opt => opt.MapFrom(src => src.first_name))
                    .ForMember(dest => dest.last_name, opt => opt.MapFrom(src => src.last_name))
                    .ForMember(dest => dest.contact_number, opt => opt.MapFrom(src => src.contact_number))
                    .ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.gender))
                    .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.address))
                    .ForMember(dest => dest.country_id, opt => opt.MapFrom(src => src.country_id))
                    .ForMember(dest => dest.state_id, opt => opt.MapFrom(src => src.state_id))
                    .ForMember(dest => dest.city, opt => opt.MapFrom(src => src.city))
                    .ForMember(dest => dest.zip_code, opt => opt.MapFrom(src => src.zip_code))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
                    .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.username))
                    .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password))
                    .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description))
                    .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.created_by))
                    .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => src.created_date))
                    .ForMember(dest => dest.modified_by, opt => opt.MapFrom(src => src.modified_by))
                    .ForMember(dest => dest.modified_date, opt => opt.MapFrom(src => src.modified_date));
            });
        }
        #endregion

        #region Public member methods.
        public DTOClient AddClient(DTOClient client)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            Client clients = new Client
            {
                first_name = client.first_name,
                last_name = client.last_name,
                contact_number = client.contact_number,
                gender = client.gender,
                address = client.address,
                country_id = client.country_id,
                state_id = client.state_id,
                city = client.city,
                zip_code = client.zip_code,
                status = client.status,
                username = client.username,
                password = client.password,
                description = client.description,
                created_by = client.created_by,
                created_date = client.created_date,
                modified_by = client.modified_by,
                modified_date = client.modified_date,
            };
            var data = _clientRepository.AddClient(clients);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Client, DTOClient>(data);
                return result;
            }
            return null;
        }

        public bool DeleteClient(long id)
        {
            bool result = _clientRepository.DeleteClient(id);
            return result ;
        }

        public IEnumerable<DTOClient> GetAllClient()
        {
            var data = _clientRepository.GetAllClient();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<Client>, IEnumerable<DTOClient>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOClient>();
        }

        public DTOClient GetClientById(long id)
        {
            var data = _clientRepository.GetClientById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Client, DTOClient>(data);
                return result;
            }
            return null;

        }
        public DTOClient UpdateClient(DTOClient client)
        {
            var data = _clientRepository.GetClientById(client.id);
            data.first_name = client.first_name;
            data.last_name = client.last_name;
            data.contact_number = client.contact_number;
            data.gender = client.gender;
            data.address = client.address;
            data.country_id = client.country_id;
            data.state_id = client.state_id;
            data.city = client.city;
            data.zip_code = client.zip_code;
            data.status = client.status;
            data.username = client.username;
            data.password = client.password;
            data.description = client.description;
            data.created_by = client.created_by;
            data.created_date = client.created_date;
            data.modified_by = client.modified_by;
            data.modified_date = client.modified_date;
            data = _clientRepository.UpdateClient(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Client, DTOClient>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
