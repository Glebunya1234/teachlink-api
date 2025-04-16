using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class NotificationsModelMDB : BaseModelMDB
    {
        private string _id_teacher = null!;

        private string _id_student = null!;

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public string id_teacher
        {
            get => _id_teacher;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BadRequestException("id_teacher cannot be empty.");
                }
                _id_teacher = value;
            }
        }

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public string id_student
        {
            get => _id_student;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BadRequestException("id_student cannot be empty.");
                }
                _id_student = value;
            }
        }

        public bool is_read { get; set; } = false;

        public bool for_teacher { get; set; } = false;
    }
}
