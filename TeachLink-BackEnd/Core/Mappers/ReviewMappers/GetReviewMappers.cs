using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.AnnouncementMappers
{
    public class GetReviewMappers : BaseMapper<ReviewsModelMDB, ReviewDTO>
    {
        public override ReviewsModelMDB ToModel(ReviewDTO dto) =>
            new ReviewsModelMDB
            {
                id = dto.id,
                id_teacher = dto.id_teachers.id,
                id_student = dto.id_students.id,
                school_subjects = dto
                    .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
                    .ToList(),
                reviews_text = dto.reviews_text,
                rating = dto.rating,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override ReviewDTO ToDto(ReviewsModelMDB model) =>
            new ReviewDTO
            {
                id = model.id,
                id_teachers = null!,
                id_students = null!,
                reviews_text = model.reviews_text,
                rating = model.rating,
                school_subjects = model
                    .school_subjects.Select(s => new SchoolSubjectDTO { Subject = s.Subject })
                    .ToList(),
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
