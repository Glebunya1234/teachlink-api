namespace TeachLink_BackEnd.Core.Entities
{
    public interface ITeachers<TSchoolSubjects, TExperience, TDegree> : IBaseEnity
        where TSchoolSubjects : ISchoolSubjects
        where TExperience : IExperiences
        where TDegree : IDegrees
    {
        string full_name { get; set; }
        string mini_description { get; set; }
        string description { get; set; }
        List<TSchoolSubjects> school_subjects { get; set; }
        TExperience experience { get; set; }
        TDegree degree { get; set; }
        string educational_institution { get; set; }
        int year_of_end { get; set; }
        string city { get; set; }
        int age { get; set; }
        string sex { get; set; }
        bool online { get; set; }
        bool show_info { get; set; }
        int price { get; set; }
    }
}
