using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface INotificationRepository
    {
        public Task Create(NotificationsModelMDB notificationsModel);
        public Task<IEnumerable<NotificationsModelMDB>> GetAll(string id_entity, bool for_teacher);
        public Task<NotificationsModelMDB> GetById(string id);
        public Task<IEnumerable<NotificationsModelMDB>> GetByIdList(IEnumerable<string> ids);
        public Task Update(string id, NotificationsModelMDB notificationsModel);
        public Task UpdateMany(IEnumerable<string> ids, bool updateFild);
    }
}
