using TeachLink_BackEnd.Core.Entities;
using TeachLink_BackEnd.Core.Models;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IReviewRepository
    {
        public Task Create(int id_teacher, int id_student, ReviewsModel reviewModel);
        public Task<IEnumerable<ReviewsModel>> GetAll(int id_teacher, int offset, int limit);
        public Task<ReviewsModel?> GetById(int id_teacher, int id_student);
        public Task Update(int id_teacher, int id_student, ReviewsModel reviewModel);
    }
}
