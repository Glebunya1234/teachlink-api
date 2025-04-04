using TeachLink_BackEnd.Core.Mappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class ExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IBaseMapper<ExperienceModelMDB, ExperienceDTO> _mapper;

        public ExperienceService(
            IExperienceRepository experienceRepository,
            IBaseMapper<ExperienceModelMDB, ExperienceDTO> mapper
        )
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExperienceDTO>> GetAll()
        {
            var degrees = await _experienceRepository.GetAll();
            return _mapper.ToDtoList(degrees);
        }

        public async Task<ExperienceDTO?> GetById(string id)
        {
            var degrees = await _experienceRepository.GetById(id);
            return _mapper.ToDto(degrees);
        }
    }
}
