using Microsoft.Extensions.Options;
using Supabase;
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnnouncementsModelMDB>> GetAll(
            string id_student,
            int offset,
            int limit
        )
        {
            throw new NotImplementedException();
        }

        public async Task<AnnouncementsModelMDB?> GetById(string id, string id_student)
        {
            throw new NotImplementedException();
        }

        public async Task Update(
            string id,
            string id_student,
            AnnouncementsModelMDB announcementsModel
        )
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string id_student)
        {
            throw new NotImplementedException();
        }
    }
}
