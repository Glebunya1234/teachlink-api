using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Processors;

namespace TeachLink_BackEnd.Core.Mappers.StudentMappers
{
    public class GetTeacherMappers : BaseMapper<TeachersModelMDB, TeacherTileDTO>
    {
        private readonly IUrlProcessor _urlProcessor;

        public GetTeacherMappers(IUrlProcessor urlProcessor)
        {
            _urlProcessor = urlProcessor;
        }

        public override TeachersModelMDB ToModel(TeacherTileDTO dto) =>
            new TeachersModelMDB
            {
                id = dto.id,
                uid = dto.uid,
                email = dto.email,
                full_name = dto.full_name,
                mini_description = dto.mini_description,
                school_subjects = dto.school_subjects.Select(s => new SchoolSubjectsModelMDB
                {
                    Subject = s.Subject,
                }),
                experience = dto.experience,
                degree = dto.degree,
                educational_institution = dto.educational_institution,
                avatarId = dto.avatarId,
                city = dto.city,
                age = dto.age,
                online = dto.online,
                review_count = dto.review_count,
                average_rating = dto.average_rating,
                phone_number = dto.phone_number,
                show_info = dto.show_info,
                price = dto.price,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override TeacherTileDTO ToDto(TeachersModelMDB model) =>
            new TeacherTileDTO
            {
                id = model.id,
                uid = model.uid,
                email = model.email,
                full_name = model.full_name,
                mini_description = model.mini_description,
                school_subjects = model.school_subjects.Select(s => new SchoolSubjectDTO
                {
                    Subject = s.Subject,
                }),
                experience = model.experience,
                avatarId = model.avatarId,
                avatarUrl = string.IsNullOrEmpty(model.avatarId)
                    ? null
                    : _urlProcessor.GetImagesUrl(model.avatarId),
                degree = model.degree,
                educational_institution = model.educational_institution,
                city = model.city,
                age = model.age,
                online = model.online,
                review_count = model.review_count,
                phone_number = model.phone_number,
                average_rating = model.average_rating,
                show_info = model.show_info,
                price = model.price,
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
