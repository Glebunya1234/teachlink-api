using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.StudentMappers
{
    public class UpdateStudentMappers : BaseMapper<StudentsModelMDB, UpdateStudentDTO>
    {
        public override StudentsModelMDB ToModel(UpdateStudentDTO dto) =>
            new StudentsModelMDB
            {
                full_name = dto.full_name,
                age = (int)dto.age,
                city = dto.city,
                sex = dto.sex,
                phone_number = dto.phone_number,
            };

        public override UpdateStudentDTO ToDto(StudentsModelMDB model)
        {
            throw new NotImplementedException();
        }
    }
}
