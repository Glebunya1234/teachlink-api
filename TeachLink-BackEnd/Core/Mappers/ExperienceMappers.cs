using TeachLink_BackEnd.Core.Mappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class GetExperienceMappers : BaseMapper<ExperienceModelMDB, ExperienceDTO>
    {
        public override ExperienceModelMDB ToModel(ExperienceDTO dto) =>
            new ExperienceModelMDB
            {
                id = dto.id,
                experience_name = dto.experience_name,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override ExperienceDTO ToDto(ExperienceModelMDB model) =>
            new ExperienceDTO
            {
                id = model.id,
                experience_name = model.experience_name,
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
