using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class SubjectRepository : MongoService<SubjectsModelMDB>, ISubjectRepository
    {
        public SubjectRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.SubjectsCollectionName) { }

        public async Task<IEnumerable<SubjectsModelMDB>?> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<SubjectsModelMDB?> GetById(string id)
        {
            return await _collection.Find(doc => doc.id == id).FirstOrDefaultAsync();
        }
    }
}
