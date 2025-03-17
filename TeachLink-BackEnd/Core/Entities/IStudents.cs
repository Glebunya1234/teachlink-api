namespace TeachLink_BackEnd.Core.Entities
{
    public interface IStudents : IBaseEnity
    {
        string full_name { get; set; }
        string city { get; set; }
        int age { get; set; }
        string sex { get; set; }
    }
}
