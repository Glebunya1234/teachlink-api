using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.DegreeMappers
{
    public class GetSubjectMappers : BaseMapper<SubjectsModelMDB, SubjectDTO>
    {
        public override SubjectsModelMDB ToModel(SubjectDTO dto) =>
            new SubjectsModelMDB
            {
                id = dto.id,
                subject = dto.subject,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override SubjectDTO ToDto(SubjectsModelMDB model) =>
            new SubjectDTO
            {
                id = model.id,
                subject = model.subject,
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
