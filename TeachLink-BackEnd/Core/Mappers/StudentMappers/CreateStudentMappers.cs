using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.StudentMappers
{
    public class CreateStudentMappers : BaseMapper<StudentsModelMDB, CreateStudentDTO>
    {
        public override StudentsModelMDB ToModel(CreateStudentDTO dto) =>
            new StudentsModelMDB
            {
                full_name = dto.full_name,
                email = dto.email,
                uid = dto.uid,
            };

        public override CreateStudentDTO ToDto(StudentsModelMDB model)
        {
            throw new NotImplementedException();
        }
    }
}
