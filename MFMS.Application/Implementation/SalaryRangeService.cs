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
    
    public class SalaryRangeService : ISalaryRangeService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly ISalaryRangeRepository _salaryRangeRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public SalaryRangeService(ISalaryRangeRepository salaryRangeRepository)
        {
            _salaryRangeRepository = salaryRangeRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SalaryRange, DTOSalaryRange>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status));
            });
        }
        #endregion

        #region Public member methods.
        public DTOSalaryRange AddSalaryRange(DTOSalaryRange salaryRange)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            SalaryRange salaryRanges = new SalaryRange
            {
                name = salaryRange.name,
                status = salaryRange.status,
            };
            var data = _salaryRangeRepository.AddSalaryRange(salaryRanges);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<SalaryRange, DTOSalaryRange>(data);
                return result;
            }
            return null;
        }

        public bool DeleteSalaryRange(int id)
        {
            bool result = _salaryRangeRepository.DeleteSalaryRange(id);
            return result;
        }

        public IEnumerable<DTOSalaryRange> GetAllSalaryRange()
        {
            var data = _salaryRangeRepository.GetAllSalaryRange();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<SalaryRange>, IEnumerable<DTOSalaryRange>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOSalaryRange>();
        }

        public DTOSalaryRange GetSalaryRangeById(int id)
        {
            var data = _salaryRangeRepository.GetSalaryRangeById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<SalaryRange, DTOSalaryRange>(data);
                return result;
            }
            return null;

        }
        public DTOSalaryRange UpdateSalaryRange(DTOSalaryRange salaryRange)
        {
            var data = _salaryRangeRepository.GetSalaryRangeById(salaryRange.id);
            data.name = salaryRange.name;
            data.status = salaryRange.status;
            data = _salaryRangeRepository.UpdateSalaryRange(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<SalaryRange, DTOSalaryRange>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
