using TeachLink_BackEnd.Core.Entities;
using TeachLink_BackEnd.Core.Models;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IStudentRepository
    {
        public Task Create(StudentsModel student);
        public Task<IEnumerable<StudentsModel>> GetAll(int offset, int limit);
        public Task<StudentsModel?> GetById(int id);
        public Task UpdateById(StudentsModel student);
    }
}
