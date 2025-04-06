using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.StudentMappers
{
    public class GetTeacherMappers : BaseMapper<TeachersModelMDB, TeacherTileDTO>
    {
        public override TeachersModelMDB ToModel(TeacherTileDTO dto) =>
            new TeachersModelMDB
            {
                id = dto.id,
                full_name = dto.full_name,
                mini_description = dto.mini_description,
                school_subjects = dto.school_subjects.Select(s => new SchoolSubjectsModelMDB
                {
                    Subject = s.Subject,
                }),
                experience = dto.experience,
                degree = dto.degree,
                educational_institution = dto.educational_institution,
                city = dto.city,
                age = dto.age,
                online = dto.online,
                show_info = dto.show_info,
                price = dto.price,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override TeacherTileDTO ToDto(TeachersModelMDB model) =>
            new TeacherTileDTO
            {
                id = model.id,
                full_name = model.full_name,
                mini_description = model.mini_description,
                school_subjects = model.school_subjects.Select(s => new SchoolSubjectDTO
                {
                    Subject = s.Subject,
                }),
                experience = model.experience,
                degree = model.degree,
                educational_institution = model.educational_institution,
                city = model.city,
                age = model.age,
                online = model.online,
                show_info = model.show_info,
                price = model.price,
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
