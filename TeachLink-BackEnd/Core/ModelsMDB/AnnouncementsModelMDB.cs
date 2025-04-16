using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class AnnouncementsModelMDB : BaseModelMDB
    {
        private string _id_student = null!;
        private string _mini_description = null!;
        private string _description = null!;
        private IEnumerable<SchoolSubjectsModelMDB> _school_subjects = null!;

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
        public IEnumerable<SchoolSubjectsModelMDB> school_subjects
        {
            get => _school_subjects;
            set
            {
                if (value == null || !value.Any())
                {
                    throw new BadRequestException("There must be at least one school subject.");
                }
                _school_subjects = value;
            }
        }

        public string mini_description
        {
            get => _mini_description;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new BadRequestException("mini_description cannot be empty.");
                if (value.Length > 200 || value.Length < 20)
                    throw new BadRequestException("mini_description must be between 20 to 200.");
                _mini_description = value;
            }
        }

        public string description
        {
            get => _description;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new BadRequestException("description cannot be empty.");
                if (value.Length > 500 || value.Length < 100)
                    throw new BadRequestException("description must be between 100 to 500.");
                _description = value;
            }
        }
    }
}
