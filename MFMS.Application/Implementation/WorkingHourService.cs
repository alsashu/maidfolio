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
    public class WorkingHourService : IWorkingHourService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IWorkingHourRepository _workingHourRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public WorkingHourService(IWorkingHourRepository workingHourRepository)
        {
            _workingHourRepository = workingHourRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WorkingHour, DTOWorkingHour>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status));
            });
        }
        #endregion

        #region Public member methods.
        public DTOWorkingHour AddWorkingHour(DTOWorkingHour workingHour)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            WorkingHour workingHours = new WorkingHour
            {
                name = workingHour.name,
                status = workingHour.status,
            };
            var data = _workingHourRepository.AddWorkingHour(workingHours);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<WorkingHour, DTOWorkingHour>(data);
                return result;
            }
            return null;
        }

        public bool DeleteWorkingHour(int id)
        {
            bool result = _workingHourRepository.DeleteWorkingHour(id);
            return result;
        }

        public IEnumerable<DTOWorkingHour> GetAllWorkingHour()
        {
            var data = _workingHourRepository.GetAllWorkingHour();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<WorkingHour>, IEnumerable<DTOWorkingHour>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOWorkingHour>();
        }

        public DTOWorkingHour GetWorkingHourById(int id)
        {
            var data = _workingHourRepository.GetWorkingHourById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<WorkingHour, DTOWorkingHour>(data);
                return result;
            }
            return null;

        }
        public DTOWorkingHour UpdateWorkingHour(DTOWorkingHour workingHour)
        {
            var data = _workingHourRepository.GetWorkingHourById(workingHour.id);
            data.name = workingHour.name;
            data.status = workingHour.status;
            data = _workingHourRepository.UpdateWorkingHour(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<WorkingHour, DTOWorkingHour>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
