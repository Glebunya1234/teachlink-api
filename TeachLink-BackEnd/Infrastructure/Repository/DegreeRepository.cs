using Supabase;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class DegreeRepository : IDegreeRepository
    {
        Client _supabase;

        public DegreeRepository(SupabaseClientFactory supabaseClientFactory)
        {
            _supabase = supabaseClientFactory.CreateClient();
        }

        public async Task<IEnumerable<DegreeModel>?> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DegreeModel?> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
