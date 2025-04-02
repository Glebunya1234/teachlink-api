using System.Dynamic;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class TeacherRepository : MongoService<TeachersModelMDB>, ITeacherRepository
    {
        public TeacherRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.TeachersCollectionName) { }

        public async Task Create(TeachersModelMDB teachersModel)
        {
            //_collection.InsertOne(newTeacher);
            throw new NotImplementedException();
        }

        public async Task<TeachersModelMDB?> GetById(string id)
        {
            return await _collection.Find(doc => doc.id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateById(string id, TeachersModelMDB teachersModels)
        {
            var res = await _collection.ReplaceOneAsync(t => t.id == id, teachersModels);
            if (res.ModifiedCount == 0)
                throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeachersModelMDB>> GetAll(
            int offset = 0,
            int limit = 20,
            SortByEnumMDB? sortBy = null,
            string? subject = null,
            bool? isOnline = null,
            string? city = null,
            int? minPrice = null,
            int? maxPrice = null
        )
        {
            var filterBuilder = Builders<TeachersModelMDB>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(subject))
            {
                filter &= filterBuilder.ElemMatch(
                    t => t.school_subjects,
                    s => s.Subject == subject
                );
            }
            if (isOnline.HasValue)
            {
                filter &= filterBuilder.Eq(t => t.online, isOnline.Value);
            }
            if (!string.IsNullOrEmpty(city))
            {
                filter &= filterBuilder.Eq(t => t.city, city);
            }
            if (minPrice.HasValue)
            {
                filter &= filterBuilder.Gte(t => t.price, minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                filter &= filterBuilder.Lte(t => t.price, maxPrice.Value);
            }

            var sortDefinition = sortBy switch
            {
                SortByEnumMDB.PriceAsc => Builders<TeachersModelMDB>.Sort.Ascending(t => t.price),
                SortByEnumMDB.PriceDesc => Builders<TeachersModelMDB>.Sort.Descending(t => t.price),
                _ => Builders<TeachersModelMDB>.Sort.Ascending(t => t.full_name),
            };

            return await _collection
                .Find(filter)
                .Sort(sortDefinition)
                .Skip(offset)
                .Limit(limit)
                .ToListAsync();
        }
    }
}
