using TeachLink_BackEnd.Core.Models;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public static class TeacherMappers
    {
        public static TeacherTileDTO MapToTeacherTileDTO(TeachersModel teacherModel)
        {
            return new TeacherTileDTO
            {
                id = teacherModel.id,
                full_name = teacherModel.full_name,
                mini_description = teacherModel.mini_description,

                school_subjects = new SchoolSubjectListDTO(
                    teacherModel.school_subjects?.Select(s => new SchoolSubjectDTO
                    {
                        Subject = s.Subject,
                        Description = s.Description,
                    }) ?? new List<SchoolSubjectDTO>()
                ),
                experience = new ExperienceDTO
                {
                    experience_name = teacherModel.experience.experience_name,
                },
                educational_institution = teacherModel.educational_institution,
                online = teacherModel.online,
                price = teacherModel.price,
                show_info = teacherModel.show_info,
                city = teacherModel.city,
                age = teacherModel.age,
                createdAt = teacherModel.createdAt,
                updatedAt = teacherModel.updatedAt,
            };
        }

        public static IEnumerable<TeacherTileDTO> MapToTeacherListResponseDTO(
            IEnumerable<TeachersModel> teachers
        )
        {
            var teacherDtos = teachers.Select(t => MapToTeacherTileDTO(t)).ToList();
            return teacherDtos;
        }

        public static TeachersModel MapToTeachersModelForCreate(TeacherTileDTO teacherDto)
        {
            return new TeachersModel
            {
                full_name = teacherDto.full_name,
                mini_description = teacherDto.mini_description,
                school_subjects = teacherDto
                    .school_subjects.schoolSubjectDTO.Select(s => new SchoolSubjectsModel
                    {
                        Subject = s.Subject,
                        Description = s.Description,
                    })
                    .ToList(),
                experience = new ExperienceModel
                {
                    experience_name = teacherDto.experience.experience_name,
                },
                educational_institution = teacherDto.educational_institution,
                online = teacherDto.online,
                price = teacherDto.price,
                show_info = teacherDto.show_info,
                city = teacherDto.city,
            };
        }

        public static TeachersModel MapToTeachersModelForCreate(CreateTeacherDTO teacherDto)
        {
            return new TeachersModel
            {
                id = teacherDto.id,
                full_name = teacherDto.full_name,
                mini_description = teacherDto.mini_description,
                description = teacherDto.description,
                school_subjects = teacherDto
                    .school_subjects.schoolSubjectDTO.Select(s => new SchoolSubjectsModel
                    {
                        Subject = s.Subject,
                        Description = s.Description,
                    })
                    .ToList(),
                experience = new ExperienceModel
                {
                    experience_name = teacherDto.experience.experience_name,
                },
                degree = new DegreeModel { degree_name = teacherDto.degree.degree_name },
                educational_institution = teacherDto.educational_institution,
                year_of_end = teacherDto.year_of_end,
                city = teacherDto.city,
                age = teacherDto.age,
                sex = teacherDto.sex,
                online = teacherDto.online,
                show_info = teacherDto.show_info,
                price = teacherDto.price,
            };
        }

        public static TeachersModel MapToTeachersModelForUpdate(UpdateTeacherDTO teacherDto)
        {
            return new TeachersModel
            {
                full_name = teacherDto.full_name,
                mini_description = teacherDto.mini_description,
                description = teacherDto.description,
                school_subjects = teacherDto
                    .school_subjects.schoolSubjectDTO.Select(s => new SchoolSubjectsModel
                    {
                        Subject = s.Subject,
                        Description = s.Description,
                    })
                    .ToList(),
                experience = new ExperienceModel
                {
                    experience_name = teacherDto.experience.experience_name,
                },
                degree = new DegreeModel { degree_name = teacherDto.degree.degree_name },
                educational_institution = teacherDto.educational_institution,
                year_of_end = teacherDto.year_of_end,
                city = teacherDto.city,
                age = teacherDto.age,
                sex = teacherDto.sex,
                online = teacherDto.online,
                show_info = teacherDto.show_info,
                price = teacherDto.price,
            };
        }
    }
}
