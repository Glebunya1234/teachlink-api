using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.StudentMappers
{
    public class GetStudentMappers : BaseMapper<StudentsModelMDB, StudentDTO>
    {
        public override StudentsModelMDB ToModel(StudentDTO dto) =>
            new StudentsModelMDB
            {
                id = dto.id,
                full_name = dto.full_name,
                age = dto.age,
                city = dto.city,
                sex = dto.sex,
                phone_number = dto.phone_number,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override StudentDTO ToDto(StudentsModelMDB model) =>
            new StudentDTO
            {
                id = model.id,
                uid = model.uid,
                full_name = model.full_name,
                age = model.age,
                city = model.city,
                sex = model.sex,
                phone_number = model.phone_number,
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
