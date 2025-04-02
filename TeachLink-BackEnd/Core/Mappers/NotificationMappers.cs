using TeachLink_BackEnd.Core.Models;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public static class NotificationMappers
    {
        public static NotificationDTO Map_From_NotificationsModel_To_NotificationDTO(
            NotificationsModel notificationsModel
        )
        {
            return new NotificationDTO
            {
                id = notificationsModel.id,
                id_teacher = new IdTeacherDTO
                {
                    id = notificationsModel.id_teacher.id,
                    full_name = notificationsModel.id_teacher.full_name,
                    createdAt = notificationsModel.id_teacher.createdAt,
                    updatedAt = notificationsModel.id_teacher.updatedAt,
                },

                id_student = new IdStudentDTO
                {
                    id = notificationsModel.id_student.id,
                    full_name = notificationsModel.id_student.full_name,
                    createdAt = notificationsModel.id_student.createdAt,
                    updatedAt = notificationsModel.id_student.updatedAt,
                },
                for_teacher = notificationsModel.for_teacher,
                is_read = notificationsModel.is_read,
                createdAt = notificationsModel.createdAt,
                updatedAt = notificationsModel.updatedAt,
            };
        }

        public static IEnumerable<NotificationDTO> Map_From_NotificationsModel_To_NotificationDTO_List(
            IEnumerable<NotificationsModel> notificationsModel
        )
        {
            return notificationsModel
                .Select(t => Map_From_NotificationsModel_To_NotificationDTO(t))
                .ToList();
        }

        public static NotificationsCreateUpdateModel Map_From_CreateNotificationDTO_To_NotificationsCreateModel(
            CreateNotificationDTO createNotificationDTO
        )
        {
            return new NotificationsCreateUpdateModel
            {
                id_teacher = createNotificationDTO.id_teacher,
                id_student = createNotificationDTO.id_student,
                is_read = createNotificationDTO.is_read,
                for_teacher = createNotificationDTO.for_teacher,
            };
        }

        public static NotificationsCreateUpdateModel Map_From_UpdateTeacherDTO_To_NotificationsModel(
            UpdateNotificationDTO updateNotificationDTO
        )
        {
            return new NotificationsCreateUpdateModel { is_read = updateNotificationDTO.is_read };
        }
    }
}
