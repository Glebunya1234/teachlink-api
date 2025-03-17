using TeachLink_BackEnd.Core.Models;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IExperienceRepository
    {
        public Task<IEnumerable<ExperienceModel>> GetAll();
        public Task<ExperienceModel> GetById(int id);
    }
}
