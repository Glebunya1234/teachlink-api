using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IAnnouncementRepository
    {
        public Task Create(AnnouncementsModelMDB announcementsModel);
        public Task<IEnumerable<AnnouncementsModelMDB>> GetAll(
            string id_student,
            int offset,
            int limit
        );
        public Task<AnnouncementsModelMDB?> GetById(string id, string id_student);
        public Task Update(string id, string id_student, AnnouncementsModelMDB announcementsModel);
        public Task Delete(string id);
    }
}
