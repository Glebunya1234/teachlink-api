using Supabase;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Client _supabase;

        public StudentRepository(SupabaseClientFactory supabaseClientFactory)
        {
            _supabase = supabaseClientFactory.CreateClient();
        }

        public async Task Create(StudentsModel student)
        {
            await _supabase.From<StudentsModel>().Insert(student);
        }

        public async Task<IEnumerable<StudentsModel>> GetAll(int offset, int limit)
        {
            var result = await _supabase.From<StudentsModel>().Get();

            return result.Models;
        }

        public async Task<StudentsModel?> GetById(int id)
        {
            var result = await _supabase.From<StudentsModel>().Where(x => x.id == id).Get();

            return result.Model;
        }

        public async Task UpdateById(StudentsModel student)
        {
            await _supabase.From<StudentsModel>().Update(student);
        }
    }
}
