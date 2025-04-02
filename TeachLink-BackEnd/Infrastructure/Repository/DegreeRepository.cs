using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Supabase;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class DegreeRepository : MongoService<DegreeModelMDB>, IDegreeRepository
    {
        public DegreeRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.DegreesCollectionName) { }

        public async Task<IEnumerable<DegreeModelMDB>?> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<DegreeModelMDB?> GetById(string id)
        {
            return await _collection.Find(doc => doc.id == id).FirstOrDefaultAsync();
        }
    }
}
