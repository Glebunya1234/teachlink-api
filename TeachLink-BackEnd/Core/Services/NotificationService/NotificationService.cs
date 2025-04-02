using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class NotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task Create(CreateNotificationDTO createNotificationDTO)
        {
            //var notificationModel =
            //    NotificationMappers.Map_From_CreateNotificationDTO_To_NotificationsCreateModel(
            //        createNotificationDTO
            //    );

            //await _notificationRepository.Create(notificationModel);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NotificationDTO>> GetAll(
            string token,
            string id_entity,
            bool for_teacher
        )
        {
            //var result = await _notificationRepository.GetAll(token, id_entity, for_teacher);
            throw new NotImplementedException();
            //return NotificationMappers.Map_From_NotificationsModel_To_NotificationDTO_List(result);
        }

        public async Task Update(
            string token,
            string id,
            UpdateNotificationDTO updateNotificationDTO
        )
        {
            throw new NotImplementedException();
            //var result = NotificationMappers.Map_From_UpdateTeacherDTO_To_NotificationsModel(
            //    updateNotificationDTO
            //);
            //await _notificationRepository.Update(token, id, result);
        }
    }
}
