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
    public class SubscriptionTypeService : ISubscriptionTypeService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public SubscriptionTypeService(ISubscriptionTypeRepository subscriptionTypeRepository)
        {
            _subscriptionTypeRepository = subscriptionTypeRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SubscriptionType, DTOSubscriptionType>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.amount))
                    .ForMember(dest => dest.country_id, opt => opt.MapFrom(src => src.country_id))
                    .ForMember(dest => dest.currency_id, opt => opt.MapFrom(src => src.currency_id))
                    .ForMember(dest => dest.validity_duration, opt => opt.MapFrom(src => src.validity_duration))
                    .ForMember(dest => dest.validity_type, opt => opt.MapFrom(src => src.validity_type))
                    .ForMember(dest => dest.points, opt => opt.MapFrom(src => src.points))
                    .ForMember(dest => dest.benefits, opt => opt.MapFrom(src => src.benefits))
                    .ForMember(dest => dest.how_it_works, opt => opt.MapFrom(src => src.how_it_works))
                    .ForMember(dest => dest.terms_and_conditions, opt => opt.MapFrom(src => src.terms_and_conditions))
                    .ForMember(dest => dest.desciption, opt => opt.MapFrom(src => src.desciption))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
                    .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.created_by))
                    .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => src.created_date))
                    .ForMember(dest => dest.modified_by, opt => opt.MapFrom(src => src.modified_by))
                    .ForMember(dest => dest.modified_date, opt => opt.MapFrom(src => src.modified_date));
            });
        }
        #endregion

        #region Public member methods.
        public DTOSubscriptionType AddSubscriptionType(DTOSubscriptionType subscriptionType)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            SubscriptionType subscriptionTypes = new SubscriptionType
            {
                name = subscriptionType.name,
                amount = subscriptionType.amount,
                country_id = subscriptionType.country_id,
                currency_id = subscriptionType.currency_id,
                validity_duration = subscriptionType.validity_duration,
                validity_type = subscriptionType.validity_type,
                points = subscriptionType.points,
                benefits = subscriptionType.benefits,
                how_it_works = subscriptionType.how_it_works,
                terms_and_conditions = subscriptionType.terms_and_conditions,
                desciption = subscriptionType.desciption,
                status = subscriptionType.status,
                created_by = subscriptionType.created_by,
                created_date = subscriptionType.created_date,
                modified_by = subscriptionType.modified_by,
                modified_date = subscriptionType.modified_date,
            };
            var data = _subscriptionTypeRepository.AddSubscriptionType(subscriptionTypes);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<SubscriptionType, DTOSubscriptionType>(data);
                return result;
            }
            return null;
        }

        public bool DeleteSubscriptionType(int id)
        {
            bool result = _subscriptionTypeRepository.DeleteSubscriptionType(id);
            return result;
        }

        public IEnumerable<DTOSubscriptionType> GetAllSubscriptionType()
        {
            var data = _subscriptionTypeRepository.GetAllSubscriptionType();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<SubscriptionType>, IEnumerable<DTOSubscriptionType>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOSubscriptionType>();
        }

        public DTOSubscriptionType GetSubscriptionTypeById(int id)
        {
            var data = _subscriptionTypeRepository.GetSubscriptionTypeById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<SubscriptionType, DTOSubscriptionType>(data);
                return result;
            }
            return null;

        }
        public DTOSubscriptionType UpdateSubscriptionType(DTOSubscriptionType subscriptionType)
        {
            var data = _subscriptionTypeRepository.GetSubscriptionTypeById(subscriptionType.id);
            data.name = subscriptionType.name;
            data.amount = subscriptionType.amount;
            data.country_id = subscriptionType.country_id;
            data.currency_id = subscriptionType.currency_id;
            data.validity_duration = subscriptionType.validity_duration;
            data.validity_type = subscriptionType.validity_type;
            data.points = subscriptionType.points;
            data.benefits = subscriptionType.benefits;
            data.how_it_works = subscriptionType.how_it_works;
            data.terms_and_conditions = subscriptionType.terms_and_conditions;
            data.desciption = subscriptionType.desciption;
            data.status = subscriptionType.status;
            data.created_by = subscriptionType.created_by;
            data.created_date = subscriptionType.created_date;
            data.modified_by = subscriptionType.modified_by;
            data.modified_date = subscriptionType.modified_date;
            data = _subscriptionTypeRepository.UpdateSubscriptionType(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<SubscriptionType, DTOSubscriptionType>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
