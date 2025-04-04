using TeachLink_BackEnd.Core.Mappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class GetDegreeMappers : BaseMapper<DegreeModelMDB, DegreeDTO>
    {
        public override DegreeModelMDB ToModel(DegreeDTO dto) =>
            new DegreeModelMDB
            {
                id = dto.id,
                degree_name = dto.degree_name,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override DegreeDTO ToDto(DegreeModelMDB model) =>
            new DegreeDTO
            {
                id = model.id,
                degree_name = model.degree_name,
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
