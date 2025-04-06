using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class SubjectService(
        ISubjectRepository subjectRepository,
        IBaseMapper<SubjectsModelMDB, SubjectDTO> mapper
    )
    {
        private readonly ISubjectRepository _subjectRepository = subjectRepository;
        private readonly IBaseMapper<SubjectsModelMDB, SubjectDTO> _mapper = mapper;

        public async Task<IEnumerable<SubjectDTO>> GetAll()
        {
            var model = await _subjectRepository.GetAll();
            return _mapper.ToDtoList(model);
        }

        public async Task<SubjectDTO?> GetById(string id)
        {
            var model = await _subjectRepository.GetById(id);
            return _mapper.ToDto(model);
        }
    }
}
