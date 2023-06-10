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
    public class CountryService : ICountryService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly ICountryRepository _countryRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Country, DTOCountry>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.code, opt => opt.MapFrom(src => src.code))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status));
            });
        }
        #endregion

        #region Public member methods.
        public DTOCountry AddCountry(DTOCountry country)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            Country countrys = new Country
            {
                name = country.name,
                code = country.code,
                status = country.status,
            };
            var data = _countryRepository.AddCountry(countrys);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Country, DTOCountry>(data);
                return result;
            }
            return null;
        }

        public bool DeleteCountry(int id)
        {
            bool result = _countryRepository.DeleteCountry(id);
            return result;
        }

        public IEnumerable<DTOCountry> GetAllCountry()
        {
            var data = _countryRepository.GetAllCountry();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<Country>, IEnumerable<DTOCountry>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOCountry>();
        }

        public DTOCountry GetCountryById(int id)
        {
            var data = _countryRepository.GetCountryById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Country, DTOCountry>(data);
                return result;
            }
            return null;

        }
        public DTOCountry UpdateCountry(DTOCountry country)
        {
            var data = _countryRepository.GetCountryById(country.id);
            data.name = country.name;
            data.code = country.code;
            data.status = country.status;
            data = _countryRepository.UpdateCountry(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Country, DTOCountry>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
    
}
