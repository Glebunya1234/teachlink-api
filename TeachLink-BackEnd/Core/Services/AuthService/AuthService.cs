using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class AuthService(
         
        ITeacherRepository teacherRepository,
        IStudentRepository studentRepository
        
    )
    {
        private readonly ITeacherRepository _teacherRepository = teacherRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;

        public async Task<AuthDTO> GetById(string id)
        {
            var isTeacher = await _teacherRepository.GetById(id) != null;
            var isStudent = await _studentRepository.GetById(id) != null;

            return new AuthDTO { isTeacher = isTeacher, isStudent = isStudent };

        }
    }
}
