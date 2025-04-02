using Microsoft.Extensions.Options;
using Supabase;
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
            throw new NotImplementedException();
        }

        public async Task<ExperienceModelMDB?> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
