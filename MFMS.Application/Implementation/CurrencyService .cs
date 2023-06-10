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
    public class CurrencyService : ICurrencyService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly ICurrencyRepository _currencyRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Currency, DTOCurrency>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.currency_name, opt => opt.MapFrom(src => src.currency_name))
                    .ForMember(dest => dest.symbol, opt => opt.MapFrom(src => src.symbol))
                    .ForMember(dest => dest.country_id, opt => opt.MapFrom(src => src.country_id))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status));
            });
        }        
        #endregion

        #region Public member methods.
        public DTOCurrency AddCurrency(DTOCurrency currency)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            Currency currencys = new Currency
            {
                currency_name = currency.currency_name,
                symbol = currency.symbol,
                country_id = currency.country_id,
                status = currency.status,
            };
            var data = _currencyRepository.AddCurrency(currencys);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Currency, DTOCurrency>(data);
                return result;
            }
            return null;
        }

        public bool DeleteCurrency(int id)
        {
            bool result = _currencyRepository.DeleteCurrency(id);
            return result;
        }

        public IEnumerable<DTOCurrency> GetAllCurrency()
        {
            var data = _currencyRepository.GetAllCurrency();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<Currency>, IEnumerable<DTOCurrency>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOCurrency>();
        }

        public DTOCurrency GetCurrencyByCountryId(int countryId)
        {
            var data = _currencyRepository.GetCurrencyByCountryId(countryId);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Currency, DTOCurrency>(data);
                return result;
            }
            return null;
        }

        public DTOCurrency GetCurrencyById(int id)
        {
            var data = _currencyRepository.GetCurrencyById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Currency, DTOCurrency>(data);
                return result;
            }
            return null;

        }
        public DTOCurrency UpdateCurrency(DTOCurrency currency)
        {
            var data = _currencyRepository.GetCurrencyById(currency.id);
            data.currency_name = currency.currency_name;
            data.symbol = currency.symbol;
            data.country_id = currency.country_id;
            data.status = currency.status;
            data = _currencyRepository.UpdateCurrency(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Currency, DTOCurrency>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
