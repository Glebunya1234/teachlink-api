using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class ExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task<IEnumerable<ExperienceDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ExperienceDTO?> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
