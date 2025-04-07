using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class AnnouncementService(
        IAnnouncementRepository announcementRepository,
        IStudentRepository studentRepository,
        IBaseMapper<AnnouncementsModelMDB, CreateAnnouncementDTO> createMapper,
        IBaseMapper<AnnouncementsModelMDB, AnnouncementDTO> getMapper
    )
    {
        private readonly IAnnouncementRepository _announcementRepository = announcementRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;
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
            var dtoList = _getMapper.ToDtoList(result).ToList();

            var studentIds = result
                .Where(n => !string.IsNullOrEmpty(n.id_student))
                .Select(n => n.id_student)
                .Distinct()
                .ToList();
            var students = await _studentRepository.GetByIdList(studentIds);
            var studentDict = students.ToDictionary(s => s.id, s => s);
            var enrichedDtos = AnnouncementHelper.EnrichNotifications(dtoList, result, studentDict);

            return enrichedDtos;
        }

        public async Task<IEnumerable<AnnouncementDTO?>> GetListById(string id_student)
        {
            var result = await _announcementRepository.GetListById(id_student);
            var dtoList = _getMapper.ToDtoList(result).ToList();

            var students = await _studentRepository.GetById(id_student);

            var enrichedDtos = AnnouncementHelper.EnrichNotifications(dtoList, result, students);
            return enrichedDtos;
        }

        public async Task<AnnouncementDTO?> GetById(string id)
        {
            var result = await _announcementRepository.GetById(id);
            var dto = _getMapper.ToDto(result);

            var students = await _studentRepository.GetById(result.id_student);

            var enrichedDto = AnnouncementHelper.EnrichNotification(dto, result, students);
            return enrichedDto;
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
