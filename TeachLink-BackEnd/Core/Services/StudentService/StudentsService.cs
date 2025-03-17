using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class StudentsService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task Create(CreateStudentDTO student)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentDTO>> GetAll(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, UpdateStudentDTO student)
        {
            throw new NotImplementedException();
        }
    }
}
