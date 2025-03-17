using TeachLink_BackEnd.Core.Entities;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class TeachersService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<TeacherTileDTO>> GetAll(int offset, int limit)
        {
            var teachers =
                await _teacherRepository.GetAll(offset, limit) ?? new List<TeachersModel>();

            return TeacherMappers.MapToTeacherListResponseDTO(teachers);
        }

        public async Task<TeacherTileDTO?> GetById(int id)
        {
            var teacher = await _teacherRepository.GetById(id);

            if (teacher is null)
                return null;

            return TeacherMappers.MapToTeacherTileDTO(teacher);
        }

        public async Task Create(CreateTeacherDTO createteacherDto)
        {
            var teacherModel = TeacherMappers.MapToTeachersModelForCreate(createteacherDto);
            await _teacherRepository.Create(teacherModel);
        }

        public async Task Update(int id, UpdateTeacherDTO updatteacherDto)
        {
            var teacherModel = TeacherMappers.MapToTeachersModelForUpdate(updatteacherDto);
            await _teacherRepository.UpdateById(id, teacherModel);
        }
    }
}
