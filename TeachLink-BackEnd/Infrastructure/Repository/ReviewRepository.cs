using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeachLink_BackEnd.Core.Models;
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
            await _collection.InsertOneAsync(reviewsModel);
        }

        public async Task<IEnumerable<ReviewsModelMDB>?> GetAll(
            string id_teacher,
            int offset,
            int limit
        )
        {
            return await _collection
                .Find(n => n.id_teacher == id_teacher)
                .Skip(offset)
                .Limit(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<ReviewsModelMDB>> GetAllByTeacherId(string teacherId)
        {
            var filter = Builders<ReviewsModelMDB>.Filter.Eq(r => r.id_teacher, teacherId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<ReviewsModelMDB?> GetById(string id_teacher, string id_student)
        {
            return await _collection
                .Find(r => r.id_teacher == id_teacher && r.id_student == id_student)
                .FirstOrDefaultAsync();
        }

        public async Task<ReviewsModelMDB?> GetById(string id)
        {
            return await _collection.Find(r => r.id == id).FirstOrDefaultAsync();
        }

        public async Task Update(string id, ReviewsModelMDB reviewModel)
        {
            var res = await _collection.ReplaceOneAsync(r => r.id == id, reviewModel);
            if (res.ModifiedCount == 0)
                throw new NotImplementedException();
        }
    }
}
