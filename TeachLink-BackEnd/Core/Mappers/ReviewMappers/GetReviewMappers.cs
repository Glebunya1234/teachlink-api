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
                id_teacher = dto.id_teachers,
                id_student = dto.id_students,
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
                id_teachers = model.id_teacher,
                reviews_text = model.reviews_text,
                id_students = model.id_student,
                rating = model.rating,
                school_subjects = model
                    .school_subjects.Select(s => new SchoolSubjectDTO { Subject = s.Subject })
                    .ToList(),
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
