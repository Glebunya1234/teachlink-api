using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class TeachersModelMDB : BaseModelMDB
    {
        private string _fullName = null!;
        private string? _miniDescription ;
        private string? _description ;
        private int _yearOfEnd = 1900;
        private int _age = 18;
        private int _price = 100;

        public decimal average_rating { get; set; } = 0;
        public int review_count { get; set; } = 0;
        public string full_name
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new BadRequestException("Full name must contain at least 1 character.");
                if (!Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]+$"))
                    throw new BadRequestException("Full name must contain only letters and spaces.");

                _fullName = value;
            }
        }

        public string? mini_description
        {
            get => _miniDescription;
            set
            {
                
                if (!string.IsNullOrWhiteSpace(value) && value.Length > 100)
                    throw new BadRequestException("Mini description must be 100 characters or less.");
                _miniDescription = value;
            }
        }

        public string? description
        {
            get => _description;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length > 500)
                    throw new BadRequestException("Description must be 500 characters or less.");
                _description = value;
            }
        }

        public IEnumerable<SchoolSubjectsModelMDB> school_subjects { get; set; } =
            new List<SchoolSubjectsModelMDB>();

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string experience { get; set; } = "67ebfffc4c69077e26568dd3";

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string degree { get; set; } = "67ebffb24c69077e26568dd0";

        public string? educational_institution { get; set; }

        public int year_of_end
        {
            get => _yearOfEnd;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                    throw new BadRequestException(
                        "Year of end must be greater than 1900 and less than or equal to the current year."
                    );
                _yearOfEnd = value;
            }
        }

        public string? city { get; set; }

        public int age
        {
            get => _age;
            set
            {
                if (value < 18)
                    throw new BadRequestException("Age must be greater than 18.");
                _age = value;
            }
        }

        public string? sex { get; set; } 

        public bool online { get; set; } = false;

        public bool show_info { get; set; } = false;

        public int price
        {
            get => _price;
            set
            {
              
                if (value < 100)
                    throw new BadRequestException("Price must be greater than 100.");
                _price = value;
            }
        }
    }
}
