using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_BackEnd.Core.Mappers.AnnouncementMappers
{
    public class CreateReviewMappers : BaseMapper<ReviewsModelMDB, CreateReviewDTO>
    {
        public override ReviewsModelMDB ToModel(CreateReviewDTO dto) =>
            new ReviewsModelMDB
            {
                id_student = dto.id_student,
                id_teacher = dto.id_teacher,
                school_subjects = dto
                    .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
                    .ToList(),
                rating = dto.rating,
                reviews_text = dto.reviews_text,
            };

        public override CreateReviewDTO ToDto(ReviewsModelMDB model)
        {
            throw new NotImplementedException();
        }
    }
}
