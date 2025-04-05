using TeachLink_BackEnd.Core.Mappers;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class AnnouncementService(
        IAnnouncementRepository announcementRepository,
        IBaseMapper<AnnouncementsModelMDB, CreateAnnouncementDTO> createMapper,
        IBaseMapper<AnnouncementsModelMDB, AnnouncementDTO> getMapper
    )
    {
        private readonly IAnnouncementRepository _announcementRepository = announcementRepository;
        private readonly IBaseMapper<AnnouncementsModelMDB, CreateAnnouncementDTO> _createMapper =
            createMapper;
        private readonly IBaseMapper<AnnouncementsModelMDB, AnnouncementDTO> _getMapper = getMapper;

        public async Task Create(CreateAnnouncementDTO createAnnouncementDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnnouncementDTO>> GetAll(
            string id_student,
            int offset,
            int limit
        )
        {
            throw new NotImplementedException();
        }

        public Task<AnnouncementDTO?> GetById(string id, string id_student)
        {
            throw new NotImplementedException();
        }

        public async Task Update(
            string id,
            string id_student,
            UpdateAnnouncementDTO updateAnnouncementDTO
        )
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
