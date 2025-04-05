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
            var announcementModel = _createMapper.ToModel(createAnnouncementDTO);
            await _announcementRepository.Create(announcementModel);
        }

        public async Task<IEnumerable<AnnouncementDTO>> GetAll(int offset, int limit)
        {
            var result = await _announcementRepository.GetAll(offset, limit);
            return _getMapper.ToDtoList(result);
        }

        public async Task<IEnumerable<AnnouncementDTO?>> GetListById(string id_student)
        {
            var result = await _announcementRepository.GetListById(id_student);
            return _getMapper.ToDtoList(result);
        }

        public async Task Update(
            string id,
            string id_student,
            UpdateAnnouncementDTO updateAnnouncementDTO
        )
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string id)
        {
            await _announcementRepository.Delete(id);
        }
    }
}
