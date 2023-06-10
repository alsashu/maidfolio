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
    public class StateService : IStateService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IStateRepository _stateRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<State, DTOState>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                     .ForMember(dest => dest.country_id, opt => opt.MapFrom(src => src.country_id))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status));
            });
        }
        #endregion

        #region Public member methods.
        public DTOState AddState(DTOState state)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            State states = new State
            {
                name = state.name,
                country_id = state.country_id,
                status = state.status,                
            };
            var data = _stateRepository.AddState(states);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<State, DTOState>(data);
                return result;
            }
            return null;
        }

        public bool DeleteState(int id)
        {
            bool result = _stateRepository.DeleteState(id);
            return result;
        }

        public IEnumerable<DTOState> GetAllState()
        {
            var data = _stateRepository.GetAllState();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<State>, IEnumerable<DTOState>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOState>();
        }

        public IEnumerable<DTOState> GetAllStateByCountry(int countryId)
        {
            var data = _stateRepository.GetAllStateByCountry(countryId);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<State>, IEnumerable<DTOState>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOState>();
        }

        public DTOState GetStateById(int id)
        {
            var data = _stateRepository.GetStateById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<State, DTOState>(data);
                return result;
            }
            return null;

        }
        public DTOState UpdateState(DTOState state)
        {
            var data = _stateRepository.GetStateById(state.id);
            data.name = state.name;
            data.country_id = state.country_id;
            data.status = state.status;
            data = _stateRepository.UpdateState(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<State, DTOState>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
