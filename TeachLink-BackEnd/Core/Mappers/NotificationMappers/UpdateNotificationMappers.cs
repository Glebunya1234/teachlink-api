using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class UpdatNotificationMappers : BaseMapper<NotificationsModelMDB, UpdateNotificationDTO>
    {
        public override NotificationsModelMDB ToModel(UpdateNotificationDTO dto) =>
            new NotificationsModelMDB { is_read = dto.is_read };

        public override UpdateNotificationDTO ToDto(NotificationsModelMDB model)
        {
            throw new NotImplementedException();
        }
    }
}
