using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Helpers
{
    public static class ReviewHelper
    {
        public static IEnumerable<ReviewDTO> EnrichNotifications(
            IEnumerable<ReviewDTO> dtoList,
            IEnumerable<ReviewsModelMDB> results,
            TeachersModelMDB teacher,
            Dictionary<string, StudentsModelMDB> studentDict
        )
        {
            return dtoList.Select(dto =>
            {
                var originalModel = results.First(r => r.id == dto.id);

                var student = studentDict.TryGetValue(originalModel.id_student, out var s)
                    ? s
                    : null;

                return dto with
                {
                    id_teachers =
                        teacher != null
                            ? new TeacherTileDTO
                            {
                                id = teacher.id,
                                uid = teacher.uid,
                                createdAt = teacher.createdAt,
                                updatedAt = teacher.updatedAt,
                                age = teacher.age,
                                city = teacher.city,
                                degree = teacher.degree,
                                full_name = teacher.full_name,
                                mini_description = teacher.mini_description,
                                educational_institution = teacher.educational_institution,
                                experience = teacher.experience,
                                online = teacher.online,
                                price = teacher.price,
                                school_subjects = teacher
                                    .school_subjects.Select(subject => new SchoolSubjectDTO
                                    {
                                        Subject = subject.Subject,
                                    })
                                    .ToList(),
                                show_info = teacher.show_info,
                            }
                            : null!,

                    id_students =
                        student != null
                            ? new StudentDTO
                            {
                                id = student.id,
                                uid = student.uid,
                                full_name = student.full_name,
                                city = student.city,
                                age = student.age,
                                sex = student.sex,
                                createdAt = student.createdAt,
                                updatedAt = student.updatedAt,
                            }
                            : null!,
                };
            });
        }

        public static ReviewDTO EnrichNotification(
            ReviewDTO dto,
            ReviewsModelMDB result,
            TeachersModelMDB teacher,
            StudentsModelMDB student
        )
        {
            return dto with
            {
                id_teachers =
                    teacher != null
                        ? new TeacherTileDTO
                        {
                            id = teacher.id,
                            uid = teacher.uid,
                            createdAt = teacher.createdAt,
                            updatedAt = teacher.updatedAt,
                            age = teacher.age,
                            city = teacher.city,
                            degree = teacher.degree,
                            full_name = teacher.full_name,
                            mini_description = teacher.mini_description,
                            educational_institution = teacher.educational_institution,
                            experience = teacher.experience,
                            online = teacher.online,
                            price = teacher.price,
                            school_subjects = teacher
                                .school_subjects.Select(subject => new SchoolSubjectDTO
                                {
                                    Subject = subject.Subject,
                                })
                                .ToList(),
                            show_info = teacher.show_info,
                        }
                        : null!,

                id_students =
                    student != null
                        ? new StudentDTO
                        {
                            id = student.id,
                            uid = student.uid,
                            full_name = student.full_name,
                            city = student.city,
                            age = student.age,
                            sex = student.sex,
                            createdAt = student.createdAt,
                            updatedAt = student.updatedAt,
                        }
                        : null!,
            };
        }
    }
}
