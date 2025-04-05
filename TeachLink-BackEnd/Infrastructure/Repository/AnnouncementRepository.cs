using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class AnnouncementRepository
        : MongoService<AnnouncementsModelMDB>,
            IAnnouncementRepository
    {
        public AnnouncementRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.AnnouncementsCollectionName) { }

        public async Task Create(AnnouncementsModelMDB announcementsModel)
        {
            await _collection.InsertOneAsync(announcementsModel);
        }

        public async Task<IEnumerable<AnnouncementsModelMDB>> GetAll(int offset, int limit)
        {
            return await _collection.Find(_ => true).Skip(offset).Limit(limit).ToListAsync();
        }

        public async Task<IEnumerable<AnnouncementsModelMDB?>> GetListById(string id_student)
        {
            return await _collection.Find(a => a.id_student == id_student).ToListAsync();
        }

        public async Task<AnnouncementsModelMDB?> GetById(string id)
        {
            return await _collection.Find(a => a.id == id).FirstOrDefaultAsync();
        }

        public async Task Update(string id, AnnouncementsModelMDB announcementsModel)
        {
            var res = await _collection.ReplaceOneAsync(a => a.id == id, announcementsModel);
            if (res.ModifiedCount == 0)
                throw new NotImplementedException();
        }

        public async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(a => a.id == id);
        }
    }
}
