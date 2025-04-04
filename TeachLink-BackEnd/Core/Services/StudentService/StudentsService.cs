using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class StudentsService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IBaseMapper<StudentsModelMDB, CreateStudentDTO> _createMapper;
        private readonly IBaseMapper<StudentsModelMDB, StudentDTO> _getMapper;
        private readonly IBaseMapper<StudentsModelMDB, UpdateStudentDTO> _updateMapper;

        public StudentsService(
            IStudentRepository studentRepository,
            IBaseMapper<StudentsModelMDB, CreateStudentDTO> createMapper,
            IBaseMapper<StudentsModelMDB, StudentDTO> getMapper,
            IBaseMapper<StudentsModelMDB, UpdateStudentDTO> updateMapper
        )
        {
            _studentRepository = studentRepository;
            _createMapper = createMapper;
            _getMapper = getMapper;
            _updateMapper = updateMapper;
        }

        public async Task Create(CreateStudentDTO student)
        {
            var studentModel = _createMapper.ToModel(student);
            await _studentRepository.Create(studentModel);
        }

        public async Task<IEnumerable<StudentDTO>> GetAll(int offset, int limit)
        {
            var students = await _studentRepository.GetAll(offset, limit);
            return _getMapper.ToDtoList(students);
        }

        public async Task<StudentDTO> GetById(string id)
        {
            var student = await _studentRepository.GetById(id);
            return _getMapper.ToDto(student);
        }

        public async Task Update(string id, UpdateStudentDTO student)
        {
            var oldmodel = await _studentRepository.GetById(id);
            UpdateHelper.ApplyPatch(student, oldmodel);
            await _studentRepository.UpdateById(id, oldmodel);
        }
    }
}
