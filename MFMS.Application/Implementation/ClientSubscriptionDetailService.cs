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
    public class ClientSubscriptionDetailService : IClientSubscriptionDetailService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IClientSubscriptionDetailRepository _clientSubscriptionDetailRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public ClientSubscriptionDetailService(IClientSubscriptionDetailRepository clientSubscriptionDetailRepository)
        {
            _clientSubscriptionDetailRepository = clientSubscriptionDetailRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientSubscriptionDetail, DTOClientSubscriptionDetail>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.client_id, opt => opt.MapFrom(src => src.client_id))
                    .ForMember(dest => dest.subscription_id, opt => opt.MapFrom(src => src.subscription_id))
                    .ForMember(dest => dest.pending_points, opt => opt.MapFrom(src => src.pending_points))
                    .ForMember(dest => dest.subscribed_date, opt => opt.MapFrom(src => src.subscribed_date))
                    .ForMember(dest => dest.validity_end_date, opt => opt.MapFrom(src => src.validity_end_date))
                    .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.created_by))
                    .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => src.created_date))
                    .ForMember(dest => dest.modified_by, opt => opt.MapFrom(src => src.modified_by))
                    .ForMember(dest => dest.modified_date, opt => opt.MapFrom(src => src.modified_date));
            });
        }
        #endregion

        #region Public member methods.
        public DTOClientSubscriptionDetail AddClientSubscriptionDetail(DTOClientSubscriptionDetail clientSubscriptionDetail)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            ClientSubscriptionDetail clientSubscriptionDetails = new ClientSubscriptionDetail
            {
                client_id = clientSubscriptionDetail.client_id,
                subscription_id = clientSubscriptionDetail.subscription_id,
                pending_points = clientSubscriptionDetail.pending_points,
                subscribed_date = clientSubscriptionDetail.subscribed_date,
                validity_end_date = clientSubscriptionDetail.validity_end_date,
                created_by = clientSubscriptionDetail.created_by,
                created_date = clientSubscriptionDetail.created_date,
                modified_by = clientSubscriptionDetail.modified_by,
                modified_date = clientSubscriptionDetail.modified_date,
            };
            var data = _clientSubscriptionDetailRepository.AddClientSubscriptionDetail(clientSubscriptionDetails);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<ClientSubscriptionDetail, DTOClientSubscriptionDetail>(data);
                return result;
            }
            return null;
        }

        public bool DeleteClientSubscriptionDetail(long id)
        {
            bool result = _clientSubscriptionDetailRepository.DeleteClientSubscriptionDetail(id);
            return result;
        }
        public IEnumerable<DTOClientSubscriptionDetail> GetClientSubscriptionDetailByClientId(long clientId)
        {
            var data = _clientSubscriptionDetailRepository.GetClientSubscriptionDetailByClientId(clientId);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<ClientSubscriptionDetail>, IEnumerable<DTOClientSubscriptionDetail>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOClientSubscriptionDetail>();
        }
        public IEnumerable<DTOClientSubscriptionDetail> GetAllClientSubscriptionDetail()
        {
            var data = _clientSubscriptionDetailRepository.GetAllClientSubscriptionDetail();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<ClientSubscriptionDetail>, IEnumerable<DTOClientSubscriptionDetail>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOClientSubscriptionDetail>();
        }

        public DTOClientSubscriptionDetail GetClientSubscriptionDetailById(long id)
        {
            var data = _clientSubscriptionDetailRepository.GetClientSubscriptionDetailById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<ClientSubscriptionDetail, DTOClientSubscriptionDetail>(data);
                return result;
            }
            return null;

        }
        public DTOClientSubscriptionDetail UpdateClientSubscriptionDetail(DTOClientSubscriptionDetail clientSubscriptionDetail)
        {
            var data = _clientSubscriptionDetailRepository.GetClientSubscriptionDetailById(clientSubscriptionDetail.id);

            data.client_id = clientSubscriptionDetail.client_id;
            data.subscription_id = clientSubscriptionDetail.subscription_id;
            data.pending_points = clientSubscriptionDetail.pending_points;
            data.subscribed_date = clientSubscriptionDetail.subscribed_date;
            data.validity_end_date = clientSubscriptionDetail.validity_end_date;
            data.created_by = clientSubscriptionDetail.created_by;
            data.created_date = clientSubscriptionDetail.created_date;
            data.modified_by = clientSubscriptionDetail.modified_by;
            data.modified_date = clientSubscriptionDetail.modified_date;
            data = _clientSubscriptionDetailRepository.UpdateClientSubscriptionDetail(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<ClientSubscriptionDetail, DTOClientSubscriptionDetail>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
