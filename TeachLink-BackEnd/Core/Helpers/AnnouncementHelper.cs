using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Helpers
{
    public static class AnnouncementHelper
    {
        public static IEnumerable<AnnouncementDTO> EnrichNotifications(
            IEnumerable<AnnouncementDTO> dtoList,
            IEnumerable<AnnouncementsModelMDB> results,
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
                                phone_number = student.phone_number,
                                createdAt = student.createdAt,
                                updatedAt = student.updatedAt,
                            }
                            : null!,
                };
            });
        }

        public static IEnumerable<AnnouncementDTO> EnrichNotifications(
            IEnumerable<AnnouncementDTO> dtoList,
            IEnumerable<AnnouncementsModelMDB> results,
            StudentsModelMDB student
        )
        {
            return dtoList.Select(dto =>
            {
                var originalModel = results.First(r => r.id == dto.id);

                return dto with
                {
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
                                phone_number = student.phone_number,
                                createdAt = student.createdAt,
                                updatedAt = student.updatedAt,
                            }
                            : null!,
                };
            });
        }

        public static AnnouncementDTO EnrichNotification(
            AnnouncementDTO dto,
            AnnouncementsModelMDB result,
            StudentsModelMDB student
        )
        {
            return dto with
            {
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
                            phone_number = student.phone_number,
                            createdAt = student.createdAt,
                            updatedAt = student.updatedAt,
                        }
                        : null!,
            };
        }
    }
}
