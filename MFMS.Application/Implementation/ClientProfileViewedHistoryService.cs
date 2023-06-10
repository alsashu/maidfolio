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
    
    public class ClientProfileViewedHistoryService : IClientProfileViewedHistoryService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IClientProfileViewedHistoryRepository _clientProfileViewedHistoryRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public ClientProfileViewedHistoryService(IClientProfileViewedHistoryRepository clientProfileViewedHistoryRepository)
        {
            _clientProfileViewedHistoryRepository = clientProfileViewedHistoryRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientProfileViewedHistory, DTOClientProfileViewedHistory>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.client_id, opt => opt.MapFrom(src => src.client_id))
                    .ForMember(dest => dest.maid_id, opt => opt.MapFrom(src => src.maid_id))
                    .ForMember(dest => dest.viewed_date, opt => opt.MapFrom(src => src.viewed_date));
            });
        }
        #endregion

        #region Public member methods.
        public DTOClientProfileViewedHistory AddClientProfileViewedHistory(DTOClientProfileViewedHistory clientProfileViewedHistory)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            ClientProfileViewedHistory clientProfileViewedHistorys = new ClientProfileViewedHistory
            {
                maid_id = clientProfileViewedHistory.maid_id,
                client_id = clientProfileViewedHistory.client_id,
                viewed_date = clientProfileViewedHistory.viewed_date,
            };
            var data = _clientProfileViewedHistoryRepository.AddClientProfileViewedHistory(clientProfileViewedHistorys);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<ClientProfileViewedHistory, DTOClientProfileViewedHistory>(data);
                return result;
            }
            return null;
        }

        public bool DeleteClientProfileViewedHistory(long id)
        {
            bool result = _clientProfileViewedHistoryRepository.DeleteClientProfileViewedHistory(id);
            return result;
        }

        public IEnumerable<DTOClientProfileViewedHistory> GetAllClientProfileViewedHistory(long clientId)
        {
            var data = _clientProfileViewedHistoryRepository.GetAllClientProfileViewedHistory(clientId);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<ClientProfileViewedHistory>, IEnumerable<DTOClientProfileViewedHistory>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOClientProfileViewedHistory>();
        }

        public DTOClientProfileViewedHistory GetClientProfileViewedHistoryById(long id)
        {
            var data = _clientProfileViewedHistoryRepository.GetClientProfileViewedHistoryById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<ClientProfileViewedHistory, DTOClientProfileViewedHistory>(data);
                return result;
            }
            return null;

        }
        public DTOClientProfileViewedHistory UpdateClientProfileViewedHistory(DTOClientProfileViewedHistory clientProfileViewedHistory)
        {
            var data = _clientProfileViewedHistoryRepository.GetClientProfileViewedHistoryById(clientProfileViewedHistory.id);
            data.maid_id = clientProfileViewedHistory.maid_id;
            data.client_id = clientProfileViewedHistory.client_id;
            data.viewed_date = clientProfileViewedHistory.viewed_date;
            data = _clientProfileViewedHistoryRepository.UpdateClientProfileViewedHistory(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<ClientProfileViewedHistory, DTOClientProfileViewedHistory>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
