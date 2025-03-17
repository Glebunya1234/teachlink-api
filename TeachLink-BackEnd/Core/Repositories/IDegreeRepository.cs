using TeachLink_BackEnd.Core.Entities;
using TeachLink_BackEnd.Core.Models;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IDegreeRepository
    {
        public Task<IEnumerable<DegreeModel>> GetAll();
        public Task<DegreeModel> GetById(int Id);
    }
}
