using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface IExperienceRepository
    {
        public Task<IEnumerable<ExperienceModelMDB>> GetAll();
        public Task<IEnumerable<ExperienceModelMDB>> GetAll(IEnumerable<string> ids);
        public Task<ExperienceModelMDB> GetById(string id);
    }
}
