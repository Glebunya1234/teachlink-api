using Supabase;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class ExperienceRepository : IExperienceRepository
    {
        Client _supabase;

        public ExperienceRepository(SupabaseClientFactory supabaseClientFactory)
        {
            _supabase = supabaseClientFactory.CreateClient();
        }

        public async Task<IEnumerable<ExperienceModel>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ExperienceModel?> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
