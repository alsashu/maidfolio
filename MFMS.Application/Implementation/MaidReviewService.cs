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
    public class MaidReviewService : IMaidReviewService
    {
        #region Private member variables.
        private readonly MapperConfiguration _mapperConfig;
        private readonly IMaidReviewRepository _maidReviewRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public Constructor
        public MaidReviewService(IMaidReviewRepository maidReviewRepository)
        {
            _maidReviewRepository = maidReviewRepository;
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MaidReview, DTOMaidReview>()
                    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                    .ForMember(dest => dest.maid_id, opt => opt.MapFrom(src => src.maid_id))
                    .ForMember(dest => dest.cient_id, opt => opt.MapFrom(src => src.cient_id))
                    .ForMember(dest => dest.rating, opt => opt.MapFrom(src => src.rating))
                    .ForMember(dest => dest.review, opt => opt.MapFrom(src => src.review))
                    .ForMember(dest => dest.comments, opt => opt.MapFrom(src => src.comments))
                    .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.created_by))
                    .ForMember(dest => dest.created_date, opt => opt.MapFrom(src => src.created_date))
                    .ForMember(dest => dest.modified_by, opt => opt.MapFrom(src => src.modified_by))
                    .ForMember(dest => dest.modified_date, opt => opt.MapFrom(src => src.modified_date));
            });
        }
        #endregion

        #region Public member methods.
        public DTOMaidReview AddMaidReview(DTOMaidReview maidReview)
        {
            var dt = DateTime.Now;
            var dt1 = DateTime.UtcNow;

            MaidReview maidReviews = new MaidReview
            {
                maid_id = maidReview.maid_id,
                cient_id = maidReview.cient_id,
                rating = maidReview.rating,
                review = maidReview.review,
                comments = maidReview.comments,
                created_by = maidReview.created_by,
                created_date = maidReview.created_date,
                modified_by = maidReview.modified_by,
                modified_date = maidReview.modified_date,
            };
            var data = _maidReviewRepository.AddMaidReview(maidReviews);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<MaidReview, DTOMaidReview>(data);
                return result;
            }
            return null;
        }

        public bool DeleteMaidReview(long id)
        {
            bool result = _maidReviewRepository.DeleteMaidReview(id);
            return result;
        }

        public IEnumerable<DTOMaidReview> GetAllMaidReview()
        {
            var data = _maidReviewRepository.GetAllMaidReview();
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<IEnumerable<MaidReview>, IEnumerable<DTOMaidReview>>(data);
                return result.ToList();
            }
            return Enumerable.Empty<DTOMaidReview>();
        }

        public DTOMaidReview GetMaidReviewById(long id)
        {
            var data = _maidReviewRepository.GetMaidReviewById(id);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<MaidReview, DTOMaidReview>(data);
                return result;
            }
            return null;

        }
        public DTOMaidReview UpdateMaidReview(DTOMaidReview maidReview)
        {
            var data = _maidReviewRepository.GetMaidReviewById(maidReview.id);
            data.cient_id = maidReview.cient_id;
            data.maid_id = maidReview.maid_id;
            data.rating = maidReview.rating;
            data.comments = maidReview.comments;
            data.created_by = maidReview.created_by;
            data.created_date = maidReview.created_date;
            data.modified_by = maidReview.modified_by;
            data.modified_date = maidReview.modified_date;
            data = _maidReviewRepository.UpdateMaidReview(data);
            if (data != null)
            {
                IMapper mapper = _mapperConfig.CreateMapper();
                var result = mapper.Map<MaidReview, DTOMaidReview>(data);
                return result;
            }
            return null;
        }

        #endregion
    }
}
