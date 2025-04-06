using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.StudentMappers
{
    public class CreateTeacherMappers : BaseMapper<TeachersModelMDB, CreateTeacherDTO>
    {
        public override TeachersModelMDB ToModel(CreateTeacherDTO dto) =>
            new TeachersModelMDB
            {
                full_name = dto.full_name,
                degree = dto.degree,
                description = dto.description,
                educational_institution = dto.educational_institution,
                experience = dto.experience,
                mini_description = dto.mini_description,
                show_info = (bool)dto.show_info,
                school_subjects = dto
                    .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
                    .ToList(),
                online = (bool)dto.online,
                price = (int)dto.price,
                year_of_end = (int)dto.year_of_end,
                age = (int)dto.age,
                city = dto.city,
                sex = dto.sex,
            };

        public override CreateTeacherDTO ToDto(TeachersModelMDB model)
        {
            throw new NotImplementedException();
        }
    }
}
