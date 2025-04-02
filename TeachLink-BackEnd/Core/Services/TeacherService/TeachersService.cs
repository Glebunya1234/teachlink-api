using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.ModelsMDB;
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

        public async Task<IEnumerable<TeacherTileDTO>> GetAll(
            int offset = 0,
            int limit = 20,
            SortByEnumMDB? sortBy = null,
            string? subjects = null,
            bool? isOnline = null,
            string? city = null,
            int? minPrice = null,
            int? maxPrice = null
        )
        {
            var teachers =
                await _teacherRepository.GetAll(
                    offset,
                    limit,
                    sortBy,
                    subjects,
                    isOnline,
                    city,
                    minPrice,
                    maxPrice
                ) ?? new List<TeachersModelMDB>();

            return TeacherMappers.MapFromTeachersModelToTeacherTileDTOList(teachers);
        }

        public async Task<TeacherTileDTO?> GetById(string id)
        {
            var teacher = await _teacherRepository.GetById(id);

            if (teacher is null)
                return null;

            return TeacherMappers.MapFromTeachersModelToTeacherTileDTO(teacher);
        }

        public async Task Create(CreateTeacherDTO createteacherDto)
        {
            //var teacherModel = TeacherMappers.MapFromCreateTeacherDTOToTeachersModel(
            //    createteacherDto
            //);
            await _teacherRepository.Create(new TeachersModelMDB { });
            //throw new NotImplementedException();
        }

        public async Task Update(string id, UpdateTeacherDTO updatteacherDto)
        {
            //var teacherModel = TeacherMappers.MapFromUpdateTeacherDTOToTeacherCreateUpdateModel(
            //    updatteacherDto
            //);
            //await _teacherRepository.UpdateById(id, teacherModel);
            throw new NotImplementedException();
        }
    }
}
