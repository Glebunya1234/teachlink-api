using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class NotificationService(
        INotificationRepository notificationRepository,
        ITeacherRepository teacherRepository,
        IStudentRepository studentRepository,
        IBaseMapper<NotificationsModelMDB, CreateNotificationDTO> createMapper,
        IBaseMapper<NotificationsModelMDB, NotificationDTO> getMapper
    )
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;
        private readonly ITeacherRepository _teacherRepository = teacherRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly IBaseMapper<NotificationsModelMDB, CreateNotificationDTO> _createMapper =
            createMapper;
        private readonly IBaseMapper<NotificationsModelMDB, NotificationDTO> _getMapper = getMapper;

        public async Task Create(CreateNotificationDTO createNotificationDTO)
        {
            var notificationModel = _createMapper.ToModel(createNotificationDTO);
            var teacher =
                await _teacherRepository.GetById(createNotificationDTO.id_teacher)
                ?? throw new NotFoundException(
                    $"Teacher with id {createNotificationDTO.id_teacher} was not found"
                );
            var student =
                await _studentRepository.GetById(createNotificationDTO.id_student)
                ?? throw new NotFoundException(
                    $"Student with id {createNotificationDTO.id_student} was not found"
                );
            await _notificationRepository.Create(notificationModel);
        }

        public async Task<IEnumerable<NotificationDTO>> GetAll(string id_entity, bool for_teacher)
        {
            var results = await _notificationRepository.GetAll(id_entity, for_teacher);

            var dtoList = _getMapper.ToDtoList(results).ToList();

            var teacherIds = results
                .Where(n => !string.IsNullOrEmpty(n.id_teacher))
                .Select(n => n.id_teacher)
                .Distinct()
                .ToList();

            var studentIds = results
                .Where(n => !string.IsNullOrEmpty(n.id_student))
                .Select(n => n.id_student)
                .Distinct()
                .ToList();

            var teachers = await _teacherRepository.GetByIdList(teacherIds);
            var students = await _studentRepository.GetByIdList(studentIds);

            var teacherDict = teachers.ToDictionary(t => t.uid, t => t);
            var studentDict = students.ToDictionary(s => s.uid, s => s);

            var enrichedDtos = NotificationHelper.EnrichNotifications(
                dtoList,
                results,
                teacherDict,
                studentDict
            );

            return enrichedDtos;
        }

        public async Task<NotificationDTO> GetById(string id)
        {
            var result =
                await _notificationRepository.GetById(id)
                ?? throw new NotFoundException($"Notification with id {id} was not found");

            var dto = _getMapper.ToDto(result);

            var teachers =
                await _teacherRepository.GetById(result.id_teacher)
                ?? throw new NotFoundException(
                    $"Teacher with id {result.id_teacher} was not found"
                );
            var students =
                await _studentRepository.GetById(result.id_student)
                ?? throw new NotFoundException(
                    $"Student with id {result.id_student} was not found"
                );

            var enrichedDto = NotificationHelper.EnrichNotification(
                dto,
                result,
                teachers,
                students
            );

            return enrichedDto;
        }

        public async Task Update(string id, UpdateNotificationDTO updateNotificationDTO)
        {
            var oldmodel =
                await _notificationRepository.GetById(id)
                ?? throw new NotFoundException($"Notification with id {id} was not found");
            UpdateHelper.ApplyPatch(updateNotificationDTO, oldmodel);
            await _notificationRepository.Update(id, oldmodel);
        }
        public async Task UpdateMany(
           UpdateNotificationListDTO updateNotificationListDTO
        )
        {
            var ids = updateNotificationListDTO.ids;
            var is_read = updateNotificationListDTO.is_read;
            if (ids == null || !ids.Any())
                throw new BadRequestException("Ids list is empty");
                        
            var s = await _notificationRepository.GetByIdList(ids)
               ?? throw new NotFoundException($"Notification with id {ids} was not found");
            await _notificationRepository.UpdateMany(ids, is_read);
        }
    }
}
