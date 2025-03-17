namespace TeachLink_BackEnd.Core.Entities
{
    public interface IReviews<TTeacher, TStudent, TSchoolSubjects, TExperience, TDegree>
        : IBaseEnity
        where TTeacher : ITeachers<TSchoolSubjects, TExperience, TDegree>
        where TStudent : IStudents
        where TSchoolSubjects : ISchoolSubjects
        where TExperience : IExperiences
        where TDegree : IDegrees
    {
        TTeacher id_teachers { get; set; }
        TStudent id_students { get; set; }
        string reviews_text { get; set; }
        TSchoolSubjects school_subjects { get; set; }
        int rating { get; set; }
    }
}
