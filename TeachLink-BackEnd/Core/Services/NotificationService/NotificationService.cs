using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class NotificationService(
        INotificationRepository notificationRepository,
        IBaseMapper<NotificationsModelMDB, CreateNotificationDTO> createMapper,
        IBaseMapper<NotificationsModelMDB, NotificationDTO> getMapper
    )
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;
        private readonly IBaseMapper<NotificationsModelMDB, CreateNotificationDTO> _createMapper =
            createMapper;
        private readonly IBaseMapper<NotificationsModelMDB, NotificationDTO> _getMapper = getMapper;

        public async Task Create(CreateNotificationDTO createNotificationDTO)
        {
            var notificationModel = _createMapper.ToModel(createNotificationDTO);
            await _notificationRepository.Create(notificationModel);
        }

        public async Task<IEnumerable<NotificationDTO>> GetAll(
            string token,
            string id_entity,
            bool for_teacher
        )
        {
            var result = await _notificationRepository.GetAll(token, id_entity, for_teacher);
            return _getMapper.ToDtoList(result);
        }

        public async Task<NotificationDTO> GetById(string token, string id)
        {
            var result = await _notificationRepository.GetById(token, id);
            return _getMapper.ToDto(result);
        }

        public async Task Update(
            string token,
            string id,
            UpdateNotificationDTO updateNotificationDTO
        )
        {
            var oldmodel = await _notificationRepository.GetById(token, id);
            UpdateHelper.ApplyPatch(updateNotificationDTO, oldmodel);
            await _notificationRepository.Update(token, id, oldmodel);
        }
    }
}
