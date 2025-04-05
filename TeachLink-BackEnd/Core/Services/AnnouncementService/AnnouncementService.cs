using Newtonsoft.Json.Linq;
using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Core.Services.TeacherService;

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

        public async Task<AnnouncementDTO?> GetById(string id)
        {
            var result = await _announcementRepository.GetById(id);
            return _getMapper.ToDto(result);
        }

        public async Task Update(string id, UpdateAnnouncementDTO updateAnnouncementDTO)
        {
            var oldmodel = await _announcementRepository.GetById(id);
            UpdateHelper.ApplyPatch(updateAnnouncementDTO, oldmodel, "school_subjects");
            if (updateAnnouncementDTO.school_subjects != null)
                oldmodel.school_subjects = updateAnnouncementDTO
                    .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
                    .ToList();
            await _announcementRepository.Update(id, oldmodel);
        }

        public async Task Delete(string id)
        {
            await _announcementRepository.Delete(id);
        }
    }
}
