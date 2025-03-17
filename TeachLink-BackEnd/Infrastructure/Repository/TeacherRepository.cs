using Supabase;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class TeacherRepository : ITeacherRepository
    {
        Client _supabase;

        public TeacherRepository(SupabaseClientFactory supabaseClientFactory)
        {
            _supabase = supabaseClientFactory.CreateClient();
        }

        public async Task Create(TeachersModel teachersModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeachersModel>?> GetAll(int offset, int limit)
        {
            throw new NotImplementedException();
            //var result = await _supabase.From<TeachersModel>().Get();

            //return result.Models;
        }

        public async Task<TeachersModel?> GetById(int id)
        {
            throw new NotImplementedException();
            //var result = await _supabase.From<TeachersModel>().Where(x => x.id == id).Get();

            //return result.Model;
        }

        public async Task UpdateById(int id, TeachersModel teachersModel)
        {
            throw new NotImplementedException();
        }
    }
}
