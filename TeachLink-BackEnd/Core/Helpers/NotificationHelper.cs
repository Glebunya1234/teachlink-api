using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Helpers
{
    public static class NotificationHelper
    {
        public static IEnumerable<NotificationDTO> EnrichNotifications(
            IEnumerable<NotificationDTO> dtoList,
            IEnumerable<NotificationsModelMDB> results,
            Dictionary<string, TeachersModelMDB> teacherDict,
            Dictionary<string, StudentsModelMDB> studentDict
        )
        {
            return dtoList.Select(dto =>
            {
                var originalModel = results.First(r => r.id == dto.id);

                var teacher = teacherDict.TryGetValue(originalModel.id_teacher, out var t)
                    ? t
                    : null;
                var student = studentDict.TryGetValue(originalModel.id_student, out var s)
                    ? s
                    : null;

                return dto with
                {
                    id_teacher =
                        teacher != null
                            ? new TeacherTileDTO
                            {
                                id = teacher.id,
                                uid = teacher.uid,
                                email = teacher.email,
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
                                phone_number = teacher.phone_number,
                                school_subjects = teacher
                                    .school_subjects.Select(subject => new SchoolSubjectDTO
                                    {
                                        Subject = subject.Subject,
                                    })
                                    .ToList(),
                                show_info = teacher.show_info,
                            }
                            : null!,

                    id_student =
                        student != null
                            ? new StudentDTO
                            {
                                id = student.id,
                                uid = student.uid,
                                email = student.email,
                                full_name = student.full_name,
                                city = student.city,
                                age = student.age,
                                phone_number = student.phone_number,
                                sex = student.sex,
                                createdAt = student.createdAt,
                                updatedAt = student.updatedAt,
                            }
                            : null!,
                };
            });
        }

        public static NotificationDTO EnrichNotification(
            NotificationDTO dto,
            NotificationsModelMDB result,
            TeachersModelMDB teacher,
            StudentsModelMDB student
        )
        {
            return dto with
            {
                id_teacher =
                    teacher != null
                        ? new TeacherTileDTO
                        {
                            id = teacher.id,
                            uid = teacher.uid,
                            email = teacher.email,
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
                            phone_number = teacher.phone_number,
                            school_subjects = teacher
                                .school_subjects.Select(subject => new SchoolSubjectDTO
                                {
                                    Subject = subject.Subject,
                                })
                                .ToList(),
                            show_info = teacher.show_info,
                        }
                        : null!,

                id_student =
                    student != null
                        ? new StudentDTO
                        {
                            id = student.id,
                            uid = student.uid,
                            email = student.email,
                            full_name = student.full_name,
                            city = student.city,
                            age = student.age,
                            sex = student.sex,
                            phone_number = student.phone_number,
                            createdAt = student.createdAt,
                            updatedAt = student.updatedAt,
                        }
                        : null!,
            };
        }
    }
}
