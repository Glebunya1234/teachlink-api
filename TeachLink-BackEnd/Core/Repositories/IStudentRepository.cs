using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IStudentRepository
    {
        public Task Create(StudentsModelMDB student);
        public Task<IEnumerable<StudentsModelMDB>> GetAll(int offset, int limit);
        public Task<StudentsModelMDB?> GetById(string id);
        public Task UpdateById(string id, StudentsModelMDB student);
    }
}
