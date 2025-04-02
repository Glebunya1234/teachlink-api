using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface INotificationRepository
    {
        public Task Create(NotificationsModelMDB notificationsModel);
        public Task<IEnumerable<NotificationsModelMDB>> GetAll(
            string token,
            string id_entity,
            bool for_teacher
        );

        public Task Update(string token, string id, NotificationsModelMDB notificationsModel);
    }
}
