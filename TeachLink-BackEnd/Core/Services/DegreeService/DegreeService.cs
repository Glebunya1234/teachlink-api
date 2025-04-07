using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class DegreeService(
        IDegreeRepository degreeRepository,
        IBaseMapper<DegreeModelMDB, DegreeDTO> mapper
    )
    {
        private readonly IDegreeRepository _degreeRepository = degreeRepository;
        private readonly IBaseMapper<DegreeModelMDB, DegreeDTO> _degreeMappers = mapper;

        public async Task<IEnumerable<DegreeDTO>> GetAll()
        {
            var degrees = await _degreeRepository.GetAll();
            if (degrees.Count() == 0)
                throw new NotFoundException($"\"Degree\" were not found");
            return _degreeMappers.ToDtoList(degrees);
        }

        public async Task<DegreeDTO?> GetById(string id)
        {
            var degrees =
                await _degreeRepository.GetById(id)
                ?? throw new NotFoundException($"\"Degree\" with id {id} was not found");
            return _degreeMappers.ToDto(degrees);
        }
    }
}
