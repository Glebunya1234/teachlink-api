using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IDegreeRepository
    {
        public Task<IEnumerable<DegreeModelMDB>> GetAll();
        public Task<DegreeModelMDB> GetById(string Id);
    }
}
