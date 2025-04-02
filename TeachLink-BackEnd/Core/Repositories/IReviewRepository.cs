using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IReviewRepository
    {
        public Task Create(ReviewsModelMDB reviewModel);
        public Task<IEnumerable<ReviewsModelMDB>> GetAll(string id_teacher, int offset, int limit);
        public Task<ReviewsModelMDB?> GetById(string id_teacher, string id_student);
        public Task Update(string id_teacher, string id_student, ReviewsModelMDB reviewModel);
    }
}
