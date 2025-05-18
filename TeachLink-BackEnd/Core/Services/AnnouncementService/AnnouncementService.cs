using Supabase.Gotrue.Mfa;
using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Processors;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Core.Services.TeacherService;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class AnnouncementService(
        IAnnouncementRepository announcementRepository,
        IStudentRepository studentRepository,
        IBaseMapper<AnnouncementsModelMDB, CreateAnnouncementDTO> createMapper,
        IBaseMapper<AnnouncementsModelMDB, AnnouncementDTO> getMapper,
        IUrlProcessor urlProcessor
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
            var student =
                await _studentRepository.GetById(createAnnouncementDTO.id_student)
                ?? throw new NotFoundException(
                    $"Student with id {createAnnouncementDTO.id_student} was not found"
                );
            await _announcementRepository.Create(announcementModel);
        }

        public async Task<PaginationResponse<AnnouncementDTO>> GetAll(int offset, int limit)
        {
            var result = await _announcementRepository.GetAll(offset, limit);
            var totalCount = await _announcementRepository.CountAsync();
            bool hasNextPage = (offset + limit) < totalCount;
            var dtoList = _getMapper.ToDtoList(result).ToList();

            var studentIds = result
                .Where(n => !string.IsNullOrEmpty(n.id_student))
                .Select(n => n.id_student)
                .Distinct()
                .ToList();

            var students = await _studentRepository.GetByIdList(studentIds);

            var studentDict = students.ToDictionary(s => s.uid, s => s);
            var enrichedDtos = AnnouncementHelper.EnrichNotifications(
                dtoList,
                result,
                studentDict,
                urlProcessor
            );
            return new PaginationResponse<AnnouncementDTO>
            {
                Items = enrichedDtos,
                HasNextPage = hasNextPage,
                TotalCount = totalCount,
            };
        }

        public async Task<IEnumerable<AnnouncementDTO?>> GetListById(string uid)
        {
            var result = await _announcementRepository.GetListById(uid);

            var dtoList = _getMapper.ToDtoList(result).ToList();

            var students = await _studentRepository.GetById(uid);

            var enrichedDtos = AnnouncementHelper.EnrichNotifications(
                dtoList,
                result,
                students,
                urlProcessor
            );
            return enrichedDtos;
        }

        public async Task<AnnouncementDTO?> GetById(string id)
        {
            var result =
                await _announcementRepository.GetById(id)
                ?? throw new NotFoundException($"Announcement with id {id} was not found");
            var dto = _getMapper.ToDto(result);

            var students =
                await _studentRepository.GetById(result.id_student)
                ?? throw new NotFoundException(
                    $"Student with id {result.id_student} was not found"
                );

            var enrichedDto = AnnouncementHelper.EnrichNotification(
                dto,
                result,
                students,
                urlProcessor
            );
            return enrichedDto;
        }

        public async Task Update(string id, UpdateAnnouncementDTO updateAnnouncementDTO)
        {
            var oldmodel =
                await _announcementRepository.GetById(id)
                ?? throw new NotFoundException($"Announcement with id {id} was not found");

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
