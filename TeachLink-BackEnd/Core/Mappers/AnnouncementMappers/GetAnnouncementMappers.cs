using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.AnnouncementMappers
{
    public class GetAnnouncementMappers : BaseMapper<AnnouncementsModelMDB, AnnouncementDTO>
    {
        public override AnnouncementsModelMDB ToModel(AnnouncementDTO dto) =>
            new AnnouncementsModelMDB
            {
                id = dto.id,
                id_student = dto.id_students.uid,
                school_subjects = dto
                    .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
                    .ToList(),
                description = dto.description,
                mini_description = dto.mini_description,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override AnnouncementDTO ToDto(AnnouncementsModelMDB model) =>
            new AnnouncementDTO
            {
                id = model.id,
                description = model.description,
                id_students = null!,
                mini_description = model.mini_description,
                school_subjects = model
                    .school_subjects.Select(s => new SchoolSubjectDTO { Subject = s.Subject })
                    .ToList(),
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
