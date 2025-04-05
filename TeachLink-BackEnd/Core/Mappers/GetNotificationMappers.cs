using TeachLink_BackEnd.Core.Mappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class GetNotificationMappers : BaseMapper<NotificationsModelMDB, NotificationDTO>
    {
        public override NotificationsModelMDB ToModel(NotificationDTO dto) =>
            new NotificationsModelMDB
            {
                id = dto.id,
                id_teacher = dto.id_teacher,
                id_student = dto.id_student,
                for_teacher = dto.for_teacher,
                is_read = dto.is_read,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override NotificationDTO ToDto(NotificationsModelMDB model) =>
            new NotificationDTO
            {
                id = model.id,
                id_teacher = model.id_teacher,
                id_student = model.id_student,
                for_teacher = model.for_teacher,
                is_read = model.is_read,
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
