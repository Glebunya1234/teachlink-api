using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface ISubjectRepository
    {
        public Task<IEnumerable<SubjectsModelMDB>> GetAll();
        public Task<SubjectsModelMDB> GetById(string Id);
    }
}
