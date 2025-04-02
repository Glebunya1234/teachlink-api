using Microsoft.Extensions.Options;
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
            throw new NotImplementedException();
        }

        public async Task<DegreeModelMDB?> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
