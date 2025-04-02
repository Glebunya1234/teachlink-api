using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface ITeacherRepository
    {
        public Task Create(TeachersModelMDB teacher);
        public Task<IEnumerable<TeachersModelMDB>> GetAll(
            int offset,
            int limit,
            SortByEnumMDB? sortBy,
            string? subjects,
            bool? isOnline,
            string? city,
            int? minPrice,
            int? maxPrice
        );

        public Task<TeachersModelMDB?> GetById(string id);
        public Task UpdateById(string id, TeachersModelMDB teacher);
    }
}
