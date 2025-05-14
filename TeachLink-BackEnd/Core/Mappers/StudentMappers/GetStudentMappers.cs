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
                email = dto.email,
                uid = dto.uid,
                age = dto.age,
                city = dto.city,
                avatarId = dto.avatarId,
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
                email = model.email,
                full_name = model.full_name,
                age = model.age,
                city = model.city,
                sex = model.sex,
                phone_number = model.phone_number,
                avatarId = model.avatarId,
                avatarUrl = string.IsNullOrEmpty(model.avatarId)
                    ? null
                    : $"http://localhost:5204/api/images/{model.avatarId}/avatar",
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
