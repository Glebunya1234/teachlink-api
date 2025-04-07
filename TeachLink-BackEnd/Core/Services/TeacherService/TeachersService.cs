using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class TeachersService(
        ITeacherRepository teacherRepository,
        IDegreeRepository degreeRepository,
        IExperienceRepository experienceRepository,
        IBaseMapper<TeachersModelMDB, CreateTeacherDTO> createMapper,
        IBaseMapper<TeachersModelMDB, TeacherTileDTO> getMapper,
        IBaseMapper<TeachersModelMDB, FullTeacherTileDTO> getFullMapper
    )
    {
        private readonly ITeacherRepository _teacherRepository = teacherRepository;
        private readonly IDegreeRepository _degreeRepository = degreeRepository;
        private readonly IExperienceRepository _experienceRepository = experienceRepository;
        private readonly IBaseMapper<TeachersModelMDB, CreateTeacherDTO> _createMapper =
            createMapper;
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
            var teachers = await _teacherRepository.GetAll(
                offset,
                limit,
                sortBy,
                subjects,
                isOnline,
                city,
                minPrice,
                maxPrice
            );
            if (teachers.Count() == 0)
                throw new NotFoundException("Teachers were not found");

            var degreeIds = teachers
                .Where(t => !string.IsNullOrEmpty(t.degree))
                .Select(t => t.degree)
                .Distinct()
                .ToList();
            var expIds = teachers
                .Where(t => !string.IsNullOrEmpty(t.experience))
                .Select(t => t.experience)
                .Distinct()
                .ToList();

            var degrees = await _degreeRepository.GetAll(degreeIds);
            if (degrees.Count() != degreeIds.Count())
                throw new NotFoundException("Degrees were not found");

            var experiences = await _experienceRepository.GetAll(expIds);
            if (experiences.Count() != expIds.Count())
                throw new NotFoundException("Experiences were not found");

            foreach (var teacher in teachers)
            {
                var degree = degrees.FirstOrDefault(d => d.id == teacher.degree);
                var exp = experiences.FirstOrDefault(e => e.id == teacher.experience);
                if (degree != null)
                {
                    teacher.degree = degree.degree_name;
                }
                if (exp != null)
                {
                    teacher.experience = exp.experience_name;
                }
            }

            return _getMapper.ToDtoList(teachers);
        }

        public async Task<FullTeacherTileDTO?> GetById(string id)
        {
            var teacher =
                await _teacherRepository.GetById(id)
                ?? throw new NotFoundException($"\"Teacher\" with id {id} was not found");

            var degree =
                await _degreeRepository.GetById(teacher.degree)
                ?? throw new NotFoundException("\"Degree\" was not found");

            var experience =
                await _experienceRepository.GetById(teacher.experience)
                ?? throw new NotFoundException("\"Experience\" was not found");

            teacher.degree = degree.degree_name;
            teacher.experience = experience.experience_name;
            return _getFullMapper.ToDto(teacher);
        }

        public async Task Create(CreateTeacherDTO createteacherDto)
        {
            var model = _createMapper.ToModel(createteacherDto);
            await _teacherRepository.Create(model);
        }

        public async Task Update(string id, UpdateTeacherDTO updatteacherDto)
        {
            var oldmodel =
                await _teacherRepository.GetById(id)
                ?? throw new NotFoundException($"\"Teacher\" with id {id} was not found");
            UpdateHelper.ApplyPatch(
                updatteacherDto,
                oldmodel,
                nameof(updatteacherDto.school_subjects)
            );

            if (updatteacherDto.school_subjects != null)
                oldmodel.school_subjects = updatteacherDto
                    .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
                    .ToList();

            await _teacherRepository.UpdateById(id, oldmodel);
        }
    }
}
