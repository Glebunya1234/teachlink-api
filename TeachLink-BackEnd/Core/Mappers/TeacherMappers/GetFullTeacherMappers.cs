using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.StudentMappers
{
    public class GetFullTeacherMappers : BaseMapper<TeachersModelMDB, FullTeacherTileDTO>
    {
        public override TeachersModelMDB ToModel(FullTeacherTileDTO dto) =>
            new TeachersModelMDB
            {
                id = dto.id,
                full_name = dto.full_name,
                mini_description = dto.mini_description,
                description = dto.description,
                school_subjects = dto.school_subjects.Select(s => new SchoolSubjectsModelMDB
                {
                    Subject = s.Subject,
                }),
                experience = dto.experience,
                degree = dto.degree,
                educational_institution = dto.educational_institution,
                city = dto.city,
                age = dto.age,
                sex = dto.sex,
                year_of_end = dto.year_of_end,
                online = dto.online,
                show_info = dto.show_info,
                price = dto.price,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override FullTeacherTileDTO ToDto(TeachersModelMDB model) =>
            new FullTeacherTileDTO
            {
                id = model.id,
                full_name = model.full_name,
                mini_description = model.mini_description,
                description = model.description,
                school_subjects = model.school_subjects.Select(s => new SchoolSubjectDTO
                {
                    Subject = s.Subject,
                }),
                experience = model.experience,
                degree = model.degree,
                year_of_end = model.year_of_end,
                educational_institution = model.educational_institution,
                city = model.city,
                age = model.age,
                sex = model.sex,
                online = model.online,
                show_info = model.show_info,
                price = model.price,
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
