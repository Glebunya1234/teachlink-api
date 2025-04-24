using System.Diagnostics;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.StudentMappers
{
    public class CreateTeacherMappers : BaseMapper<TeachersModelMDB, CreateTeacherDTO>
    {
        public override TeachersModelMDB ToModel(CreateTeacherDTO dto) =>
            
            new TeachersModelMDB
            {
                full_name = dto.full_name,
                uid = dto.uid

            };
        

        public override CreateTeacherDTO ToDto(TeachersModelMDB model)
        {
            throw new NotImplementedException();
        }
    }
}
