using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class ExperienceRepository : MongoService<ExperienceModelMDB>, IExperienceRepository
    {
        public ExperienceRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.ExperiencesCollectionName) { }

        public async Task<IEnumerable<ExperienceModelMDB>?> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<ExperienceModelMDB?> GetById(string id)
        {
            return await _collection.Find(doc => doc.id == id).FirstOrDefaultAsync();
        }
    }
}
