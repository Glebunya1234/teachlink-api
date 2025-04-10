using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class StudentsService(
        IStudentRepository studentRepository,
        IBaseMapper<StudentsModelMDB, CreateStudentDTO> createMapper,
        IBaseMapper<StudentsModelMDB, StudentDTO> getMapper
    )
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly IBaseMapper<StudentsModelMDB, CreateStudentDTO> _createMapper =
            createMapper;
        private readonly IBaseMapper<StudentsModelMDB, StudentDTO> _getMapper = getMapper;

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
            var student =
                await _studentRepository.GetById(id)
                ?? throw new NotFoundException($"Student with id {id} was not found");
            return _getMapper.ToDto(student);
        }

        public async Task Update(string id, UpdateStudentDTO student)
        {
            var oldmodel =
                await _studentRepository.GetById(id)
                ?? throw new NotFoundException($"Students with id {id} was not found");
            UpdateHelper.ApplyPatch(student, oldmodel);
            await _studentRepository.UpdateById(id, oldmodel);
        }
    }
}
