using Microsoft.Extensions.Options;
using Supabase;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class StudentRepository : MongoService<StudentsModelMDB>, IStudentRepository
    {
        public StudentRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.StudentsCollectionName) { }

        public async Task Create(StudentsModelMDB student)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentsModelMDB>> GetAll(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentsModelMDB?> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateById(string id, StudentsModelMDB student)
        {
            throw new NotImplementedException();
        }
    }
}
