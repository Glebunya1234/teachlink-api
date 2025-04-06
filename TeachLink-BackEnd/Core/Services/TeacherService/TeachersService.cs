using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class TeachersService(
        ITeacherRepository _teacherRepository,
        IBaseMapper<TeachersModelMDB, CreateTeacherDTO> teacherRepository,
        IBaseMapper<TeachersModelMDB, TeacherTileDTO> getMapper,
        IBaseMapper<TeachersModelMDB, FullTeacherTileDTO> getFullMapper
    )
    {
        private readonly ITeacherRepository _teacherRepository = _teacherRepository;

        private readonly IBaseMapper<TeachersModelMDB, CreateTeacherDTO> _createMapper =
            teacherRepository;
        private readonly IBaseMapper<TeachersModelMDB, TeacherTileDTO> _getMapper = getMapper;
        private readonly IBaseMapper<TeachersModelMDB, FullTeacherTileDTO> _getFullMapper =
            getFullMapper;

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

            return _getMapper.ToDtoList(teachers);
        }

        public async Task<FullTeacherTileDTO?> GetById(string id)
        {
            var teacher = await _teacherRepository.GetById(id);

            return _getFullMapper.ToDto(teacher);
        }

        public async Task Create(CreateTeacherDTO createteacherDto)
        {
            var model = _createMapper.ToModel(createteacherDto);
            await _teacherRepository.Create(model);
        }

        public async Task Update(string id, UpdateTeacherDTO updatteacherDto)
        {
            var oldmodel = await _teacherRepository.GetById(id);
            UpdateHelper.ApplyPatch(
                updatteacherDto,
                oldmodel,
                nameof(updatteacherDto.school_subjects)
            );

            if (updatteacherDto.school_subjects != null)
                UpdateHelper.ApplyPatch(updatteacherDto.school_subjects, oldmodel.school_subjects);
            await _teacherRepository.UpdateById(id, oldmodel);
        }
    }
}
