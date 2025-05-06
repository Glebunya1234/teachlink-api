using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class ReviewsModelMDB : BaseModelMDB
    {
        private string _reviewsText = null!;

        private int _rating { get; set; } = 5;

        private string _idTeacher = null!;

        private string _idStudent = null!;

        [Required]
        public string id_teacher
        {
            get => _idTeacher;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BadRequestException("id_teacher cannot be empty.");
                }
                _idTeacher = value;
            }
        }

        [Required]
        public string id_student
        {
            get => _idStudent;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BadRequestException("id_student cannot be empty.");
                }
                _idStudent = value;
            }
        }

        public IEnumerable<SchoolSubjectsModelMDB> school_subjects { get; set; } = null!;

        [BsonRequired]
        public string reviews_text
        {
            get => _reviewsText;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BadRequestException("reviews_text cannot be empty.");
                }
                if (value.Length > 500)
                {
                    throw new BadRequestException(
                        "reviews_text cannot be longer than 300 characters."
                    );
                }
                _reviewsText = value;
            }
        }

        public int rating
        {
            get => _rating;
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new BadRequestException("rating must be between 1 and 5.");
                }
                _rating = value;
            }
        }
    }
}
