using System.Collections;
using TeachLink_BackEnd.Core.Entities;
using TeachLink_BackEnd.Core.Models;

namespace TeachLink_BackEnd.Core.Repositories
{
    public interface ITeacherRepository
    {
        public Task Create(TeachersModel teacher);
        public Task<IEnumerable<TeachersModel>> GetAll(int offset, int limit);
        public Task<TeachersModel> GetById(int id);
        public Task UpdateById(int id, TeachersModel teacher);
    }
}
