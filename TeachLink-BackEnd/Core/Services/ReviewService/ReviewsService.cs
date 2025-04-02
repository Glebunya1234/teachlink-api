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

        public async Task Create(CreateReviewDTO createReview)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewDTO>> GetAll(string id_teacher, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewDTO?> GetById(string id_teacher, string id_student)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string id_teacher, string id_student, UpdateReviewDTO review)
        {
            throw new NotImplementedException();
        }
    }
}
