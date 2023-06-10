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
    public class MaidService : IMaidService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IMaidRepository _maidRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public MaidService(IMaidRepository maidRepository)
        {
            _maidRepository = maidRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Maid, DTOMaid>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.first_name, opt => opt.MapFrom(src => src.first_name))
                    .ForMember(dest => dest.last_name, opt => opt.MapFrom(src => src.last_name))
                    .ForMember(dest => dest.contact_number, opt => opt.MapFrom(src => src.contact_number))
                    .ForMember(dest => dest.age, opt => opt.MapFrom(src => src.age))
                    .ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.gender))
                    .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.address))
                    .ForMember(dest => dest.country_id, opt => opt.MapFrom(src => src.country_id))
                    .ForMember(dest => dest.state_id, opt => opt.MapFrom(src => src.state_id))
                    .ForMember(dest => dest.city, opt => opt.MapFrom(src => src.city))
                    .ForMember(dest => dest.zip_code, opt => opt.MapFrom(src => src.zip_code))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
                    .ForMember(dest => dest.working_hours_id, opt => opt.MapFrom(src => src.working_hours_id))
                    .ForMember(dest => dest.job_skills_id, opt => opt.MapFrom(src => src.job_skills_id))
                    .ForMember(dest => dest.availibility, opt => opt.MapFrom(src => src.availibility))
                    .ForMember(dest => dest.expected_date_of_availibility, opt => opt.MapFrom(src => src.expected_date_of_availibility))
                    .ForMember(dest => dest.languages_known, opt => opt.MapFrom(src => src.languages_known))
                    .ForMember(dest => dest.salary_range_id, opt => opt.MapFrom(src => src.salary_range_id))
                    .ForMember(dest => dest.document_type_id, opt => opt.MapFrom(src => src.document_type_id))
                    .ForMember(dest => dest.document_photo, opt => opt.MapFrom(src => src.document_photo))
                    .ForMember(dest => dest.reference, opt => opt.MapFrom(src => src.reference))
                    .ForMember(dest => dest.about_maid, opt => opt.MapFrom(src => src.about_maid))
                    .ForMember(dest => dest.comments_by_admin, opt => opt.MapFrom(src => src.comments_by_admin))
                    .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.username))
                    .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password))
                    .ForMember(dest => dest.is_verified, opt => opt.MapFrom(src => src.is_verified))
                    .ForMember(dest => dest.is_block_listed, opt => opt.MapFrom(src => src.is_block_listed))
                    .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.created_by))
                    .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => src.created_date))
                    .ForMember(dest => dest.modified_by, opt => opt.MapFrom(src => src.modified_by))
                    .ForMember(dest => dest.modified_date, opt => opt.MapFrom(src => src.modified_date));
            });
        }
        #endregion

        #region Public member methods.
        public DTOMaid Add(DTOMaid maid)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            Maid maids = new Maid
            {
                first_name = maid.first_name,
                last_name = maid.last_name,
                contact_number = maid.contact_number,
                age = maid.age,
                gender = maid.gender,
                address = maid.address,
                country_id = maid.country_id,
                state_id = maid.state_id,
                city = maid.city,
                zip_code = maid.zip_code,
                status = maid.status,
                working_hours_id = maid.working_hours_id,
                job_skills_id = maid.job_skills_id,
                availibility = maid.availibility,
                expected_date_of_availibility = maid.expected_date_of_availibility,
                languages_known = maid.languages_known,
                salary_range_id = maid.salary_range_id,
                photo = maid.photo,
                document_type_id = maid.document_type_id,
                document_photo = maid.document_photo,
                reference = maid.reference,
                about_maid = maid.about_maid,
                comments_by_admin = maid.comments_by_admin,
                username = maid.username,
                password = maid.password,
                is_verified = maid.is_verified,
                is_block_listed = maid.is_block_listed,
                created_by = maid.created_by,
                created_date = maid.created_date,
                modified_by = maid.modified_by,
                modified_date = maid.modified_date,
            };
            var data = _maidRepository.Add(maids);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Maid, DTOMaid>(data);
                return result;
            }
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTOMaid> GetAll()
        {
            var data = _maidRepository.GetAll();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<Maid>, IEnumerable<DTOMaid>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOMaid>();
        }

        public DTOMaid GetById(int id)
        {
            var data = _maidRepository.GetById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<Maid, DTOMaid>(data);
                return result;
            }
            return null;

        }
        public DTOMaid Update(DTOMaid maid)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
