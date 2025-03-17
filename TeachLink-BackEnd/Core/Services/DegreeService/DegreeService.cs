using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class DegreeService
    {
        private readonly IDegreeRepository _degreeRepository;

        public DegreeService(IDegreeRepository degreeRepository)
        {
            _degreeRepository = degreeRepository;
        }

        public async Task<IEnumerable<DegreeDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DegreeDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
