using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.NotificationMappers
{
    public class CreateNotificationMappers
        : BaseMapper<NotificationsModelMDB, CreateNotificationDTO>
    {
        public override NotificationsModelMDB ToModel(CreateNotificationDTO dto) =>
            new NotificationsModelMDB
            {
                id_teacher = dto.id_teacher,
                id_student = dto.id_student,
                for_teacher = dto.for_teacher,
                is_read = dto.is_read,
            };

        public override CreateNotificationDTO ToDto(NotificationsModelMDB model)
        {
            throw new NotImplementedException();
        }
    }
}
