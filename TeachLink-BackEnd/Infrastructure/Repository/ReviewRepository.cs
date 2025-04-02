using Microsoft.Extensions.Options;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class ReviewRepository : MongoService<ReviewsModelMDB>, IReviewRepository
    {
        public ReviewRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.ReviewsCollectionName) { }

        public async Task Create(ReviewsModelMDB reviewsModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewsModelMDB>?> GetAll(
            string id_teacher,
            int offset,
            int limit
        )
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewsModelMDB?> GetById(string id_teacher, string id_student)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string id_teacher, string id_student, ReviewsModelMDB reviewModel)
        {
            throw new NotImplementedException();
        }
    }
}
