using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class ReviewsService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewsService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task Create(int id_teacher, int id_student, CreateReviewDTO createReview)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewDTO>> GetAll(int id_teacher, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewDTO?> GetById(int id_teacher, int id_student)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id_teacher, int id_student, UpdateReviewDTO reviewModel)
        {
            throw new NotImplementedException();
        }
    }
}
