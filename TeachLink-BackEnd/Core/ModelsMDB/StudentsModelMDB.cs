using System.Text.RegularExpressions;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class StudentsModelMDB : BaseModelMDB
    {
        public string uid { get; set; } = null!;
        private string _fullName = null!;
        private int _age = 0;

        public string full_name
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new BadRequestException("Full name must contain at least 1 character.");
                if (!Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]+$"))
                    throw new BadRequestException(
                        "Full name must contain only letters and spaces."
                    );

                _fullName = value;
            }
        }
        public string? city { get; set; }

        public int age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new BadRequestException("Age must be greater than 0.");
                _age = value;
            }
        }
        public string? sex { get; set; }
        public string? phone_number { get; set; }
    }
}
