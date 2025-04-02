using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public static class TeacherMappers
    {
        public static TeacherTileDTO MapFromTeachersModelToTeacherTileDTO(
            TeachersModelMDB teacherModel
        )
        {
            return new TeacherTileDTO
            {
                id = teacherModel.id,
                full_name = teacherModel.full_name,
                mini_description = teacherModel.mini_description,
                school_subjects = teacherModel
                    .school_subjects.Select(s => new SchoolSubjectDTO { Subject = s.Subject })
                    .ToList(),
                experience = new ExperienceDTO { experience_name = teacherModel.experience },
                //degree = new DegreeDTO { degree_name = teacherModel.degree.degree_name },

                educational_institution = teacherModel.educational_institution,
                online = teacherModel.online,
                price = teacherModel.price,
                show_info = teacherModel.show_info,
                city = teacherModel.city,
                age = teacherModel.age,
            };
        }

        public static IEnumerable<TeacherTileDTO> MapFromTeachersModelToTeacherTileDTOList(
            IEnumerable<TeachersModelMDB> teachers
        )
        {
            var teacherDtos = teachers
                .Select(t => MapFromTeachersModelToTeacherTileDTO(t))
                .ToList();
            return teacherDtos;
        }

        //public static TeachersModelMDB MapFromTeacherTileDTOToTeachersModel(
        //    TeacherTileDTO teacherDto
        //)
        //{
        //    return new TeachersModelMDB
        //    {
        //        full_name = teacherDto.full_name,
        //        mini_description = teacherDto.mini_description,
        //        school_subjects = teacherDto
        //            .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
        //            .ToList(),

        //        experience = teacherDto.experience.ToString(),
        //        educational_institution = teacherDto.educational_institution,
        //        online = teacherDto.online,
        //        price = teacherDto.price,
        //        show_info = teacherDto.show_info,
        //        city = teacherDto.city,
        //    };
        //}

        //public static TeachersModelMDB MapFromCreateTeacherDTOToTeachersModel(
        //    CreateTeacherDTO teacherDto
        //)
        //{
        //    return new TeachersModelMDB
        //    {
        //        id = teacherDto.id,
        //        full_name = teacherDto.full_name,
        //        mini_description = teacherDto.mini_description,
        //        description = teacherDto.description,
        //        school_subjects = teacherDto
        //            .school_subjects.Select(s => new SchoolSubjectsModel { Subject = s.Subject })
        //            .ToList(),

        //        experience_id = teacherDto.experience,
        //        degree_id = teacherDto.degree,
        //        educational_institution = teacherDto.educational_institution,
        //        year_of_end = teacherDto.year_of_end,
        //        city = teacherDto.city,
        //        age = teacherDto.age,
        //        sex = teacherDto.sex,
        //        online = teacherDto.online,
        //        show_info = teacherDto.show_info,
        //        price = teacherDto.price,
        //    };
        //}

        //public static TeachersModelMDB MapFromUpdateTeacherDTOToTeacherCreateUpdateModel(
        //    UpdateTeacherDTO teacherDto
        //)
        //{
        //    return new TeachersModelMDB
        //    {
        //        full_name = teacherDto.full_name,
        //        mini_description = teacherDto.mini_description,
        //        description = teacherDto.description,
        //        school_subjects = teacherDto
        //            .school_subjects.Select(s => new SchoolSubjectsModel { Subject = s.Subject })
        //            .ToList(),

        //        experience_id = teacherDto.experience,

        //        degree_id = teacherDto.degree,
        //        educational_institution = teacherDto.educational_institution,
        //        year_of_end = teacherDto.year_of_end,
        //        city = teacherDto.city,
        //        age = teacherDto.age,
        //        sex = teacherDto.sex,
        //        online = teacherDto.online,
        //        show_info = teacherDto.show_info,
        //        price = teacherDto.price,
        //    };
        //}
    }
}
