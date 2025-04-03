using System.Text.RegularExpressions;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class StudentsModelMDB : BaseModelMDB
    {
        private string _fullName = null!;
        private int _age = 0;

        public string full_name
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name must contain at least 1 character.");
                if (!Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]+$"))
                    throw new ArgumentException("Full name must contain only letters and spaces.");

                _fullName = value;
            }
        }
        public string city { get; set; } = null!;

        public int age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age must be greater than 0.");
                _age = value;
            }
        }
        public string sex { get; set; } = null!;
    }
}
