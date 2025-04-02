using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeachLink_BackEnd.Core.Models;
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

        public async Task Create(NotificationsModelMDB notificationsModel)
        {
            await _collection.InsertOneAsync(notificationsModel);
        }

        public async Task<IEnumerable<NotificationsModelMDB>> GetAll(
            string token,
            string id_entity,
            bool for_teacher
        )
        {
            return await _collection
                .Find(n =>
                    n.for_teacher == for_teacher
                    && (n.id_teacher == id_entity || n.id_student == id_entity)
                )
                .ToListAsync();
        }

        public async Task Update(string token, string id, NotificationsModelMDB notificationsModel)
        {
            var res = await _collection.ReplaceOneAsync(n => n.id == id, notificationsModel);
            if (res.ModifiedCount == 0)
                throw new NotImplementedException();
        }
    }
}
