using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class DegreeService
    {
        private readonly IDegreeRepository _degreeRepository;
        private readonly IBaseMapper<DegreeModelMDB, DegreeDTO> _degreeMappers;

        public DegreeService(
            IDegreeRepository degreeRepository,
            IBaseMapper<DegreeModelMDB, DegreeDTO> mapper
        )
        {
            _degreeRepository = degreeRepository;
            _degreeMappers = mapper;
        }

        public async Task<IEnumerable<DegreeDTO>> GetAll()
        {
            var degrees = await _degreeRepository.GetAll();
            return _degreeMappers.ToDtoList(degrees);
        }

        public async Task<DegreeDTO?> GetById(string id)
        {
            var degrees = await _degreeRepository.GetById(id);
            return _degreeMappers.ToDto(degrees);
        }
    }
}
