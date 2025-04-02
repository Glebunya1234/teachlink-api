namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class StudentsModelMDB : BaseModelMDB
    {
        public string full_name { get; set; } = string.Empty;

        public string city { get; set; } = string.Empty;

        public int age { get; set; } = 0;

        public string sex { get; set; } = string.Empty;
    }
}
