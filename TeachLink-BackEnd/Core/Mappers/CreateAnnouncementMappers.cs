using TeachLink_BackEnd.Core.Mappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class CreateAnnouncementMappers
        : BaseMapper<AnnouncementsModelMDB, CreateAnnouncementDTO>
    {
        public override AnnouncementsModelMDB ToModel(CreateAnnouncementDTO dto) =>
            new AnnouncementsModelMDB
            {
                id_student = dto.id_student,
                school_subjects = dto
                    .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
                    .ToList(),
                description = dto.description,
                mini_description = dto.mini_description,
            };

        public override CreateAnnouncementDTO ToDto(AnnouncementsModelMDB model)
        {
            throw new NotImplementedException();
        }
    }
}
