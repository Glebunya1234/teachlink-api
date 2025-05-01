using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IAnnouncementRepository
    {
        public Task Create(AnnouncementsModelMDB announcementsModel);
        public Task<IEnumerable<AnnouncementsModelMDB>> GetAll(int offset, int limit);
        public Task<IEnumerable<AnnouncementsModelMDB?>> GetListById(string id_student);
        public Task<AnnouncementsModelMDB?> GetById(string id);
        public Task Update(string id, AnnouncementsModelMDB announcementsModel);
        public Task Delete(string id);
        public Task<int> CountAsync();
    }
}
