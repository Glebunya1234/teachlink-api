using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class ReviewsModelMDB : BaseModelMDB
    {
        private string _reviewsText = string.Empty;

        private int _rating { get; set; } = 5;

        private string _idTeacher = null!;

        private string _idStudent = null!;

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public string id_teacher
        {
            get => _idTeacher;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("id_teacher cannot be empty.");
                }
                _idTeacher = value;
            }
        }

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public string id_student
        {
            get => _idStudent;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("id_student cannot be empty.");
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
                    throw new ArgumentException("reviews_text cannot be empty.");
                }
                if (value.Length > 100)
                {
                    throw new ArgumentException(
                        "reviews_text cannot be longer than 100 characters."
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
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "rating must be between 1 and 5."
                    );
                }
                _rating = value;
            }
        }
    }
}
