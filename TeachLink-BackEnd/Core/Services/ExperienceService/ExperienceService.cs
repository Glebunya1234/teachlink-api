using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class ExperienceService(
        IExperienceRepository experienceRepository,
        IBaseMapper<ExperienceModelMDB, ExperienceDTO> mapper
    )
    {
        private readonly IExperienceRepository _experienceRepository = experienceRepository;
        private readonly IBaseMapper<ExperienceModelMDB, ExperienceDTO> _mapper = mapper;

        public async Task<IEnumerable<ExperienceDTO>> GetAll()
        {
            var experience = await _experienceRepository.GetAll();

            return _mapper.ToDtoList(experience);
        }

        public async Task<ExperienceDTO?> GetById(string id)
        {
            var experience =
                await _experienceRepository.GetById(id)
                ?? throw new NotFoundException($"\"Experience\" with id {id} was not found");
            return _mapper.ToDto(experience);
        }
    }
}
