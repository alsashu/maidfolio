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
    public class LanguageService : ILanguageService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly ILanguageRepository _languageRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Language, DTOLanguage>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.language_name, opt => opt.MapFrom(src => src.language_name))
                    .ForMember(dest => dest.country_id, opt => opt.MapFrom(src => src.country_id))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status));
            });
        }
        #endregion

        #region Public member methods.
        public DTOLanguage AddLanguage(DTOLanguage language)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            Language languages = new Language
            {
                language_name = language.language_name,
                country_id = language.country_id,
                status = language.status,
            };
            var data = _languageRepository.AddLanguage(languages);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Language, DTOLanguage>(data);
                return result;
            }
            return null;
        }

        public bool DeleteLanguage(int id)
        {
            bool result = _languageRepository.DeleteLanguage(id);
            return result;
        }

        public IEnumerable<DTOLanguage> GetAllLanguage()
        {
            var data = _languageRepository.GetAllLanguage();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<Language>, IEnumerable<DTOLanguage>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOLanguage>();
        }

        public IEnumerable<DTOLanguage> GetAllLanguageByCountryId(int countryId)
        {
            var data = _languageRepository.GetAllLanguageByCountryId(countryId);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<Language>, IEnumerable<DTOLanguage>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOLanguage>();
        }

        public DTOLanguage GetLanguageById(int id)
        {
            var data = _languageRepository.GetLanguageById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Language, DTOLanguage>(data);
                return result;
            }
            return null;

        }
        public DTOLanguage UpdateLanguage(DTOLanguage language)
        {
            var data = _languageRepository.GetLanguageById(language.id);
            data.language_name = language.language_name;
            data.country_id = language.country_id;
            data.status = language.status;
            data = _languageRepository.UpdateLanguage(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Language, DTOLanguage>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
