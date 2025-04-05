using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class ReviewsService(
        IReviewRepository reviewRepository,
        IBaseMapper<ReviewsModelMDB, CreateReviewDTO> createMapper,
        IBaseMapper<ReviewsModelMDB, ReviewDTO> getMapper
    )
    {
        private readonly IReviewRepository _reviewRepository = reviewRepository;
        private readonly IBaseMapper<ReviewsModelMDB, CreateReviewDTO> _createMapper = createMapper;
        private readonly IBaseMapper<ReviewsModelMDB, ReviewDTO> _getMapper = getMapper;

        public async Task Create(CreateReviewDTO createReview)
        {
            var reviewModel = _createMapper.ToModel(createReview);
            await _reviewRepository.Create(reviewModel);
        }

        public async Task<IEnumerable<ReviewDTO>> GetAll(string id_teacher, int offset, int limit)
        {
            var result = await _reviewRepository.GetAll(id_teacher, offset, limit);
            return _getMapper.ToDtoList(result);
        }

        public async Task<ReviewDTO?> GetById(string id_teacher, string id_student)
        {
            var result = await _reviewRepository.GetById(id_teacher, id_student);
            return _getMapper.ToDto(result);
        }

        public async Task Update(string id_teacher, string id_student, UpdateReviewDTO review)
        {
            var oldmodel = await _reviewRepository.GetById(id_teacher, id_student);
            UpdateHelper.ApplyPatch(review, oldmodel, "school_subjects");
            if (review.school_subjects != null)
                oldmodel.school_subjects = review
                    .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
                    .ToList();
            await _reviewRepository.Update(id_teacher, id_student, oldmodel);
        }
    }
}
