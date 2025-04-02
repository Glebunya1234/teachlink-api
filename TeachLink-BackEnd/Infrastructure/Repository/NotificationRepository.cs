using Microsoft.Extensions.Options;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class NotificationRepository
        : MongoService<NotificationsModelMDB>,
            INotificationRepository
    {
        public NotificationRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.NotificationsCollectionName) { }

        public Task Create(NotificationsModelMDB notificationsModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NotificationsModelMDB>> GetAll(
            string token,
            string id_entity,
            bool for_teacher
        )
        {
            throw new NotImplementedException();
        }

        public async Task Update(string token, string id, NotificationsModelMDB notificationsModel)
        {
            throw new NotImplementedException();
        }
    }
}
