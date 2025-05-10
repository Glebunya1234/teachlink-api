using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class StudentRepository : MongoService<StudentsModelMDB>, IStudentRepository
    {
        public StudentRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.StudentsCollectionName) { }

        public async Task Create(StudentsModelMDB student)
        {
            await _collection.InsertOneAsync(student);
        }

        public async Task<IEnumerable<StudentsModelMDB>> GetAll(int offset, int limit)
        {
            return await _collection.Find(_ => true).Skip(offset).Limit(limit).ToListAsync();
        }

        public async Task<IEnumerable<StudentsModelMDB>> GetByIdList(IEnumerable<string> ids)
        {
            return await _collection.Find(stud => ids.Contains(stud.uid)).ToListAsync();
        }

        public async Task<StudentsModelMDB?> GetById(string uid)
        {
            return await _collection.Find(s => s.uid == uid).FirstOrDefaultAsync();
        }

        public async Task UpdateById(string id, StudentsModelMDB student)
        {
            var res = await _collection.ReplaceOneAsync(s => s.uid == id, student);
            if (res.ModifiedCount == 0)
                throw new NotImplementedException();
        }
    }
}
