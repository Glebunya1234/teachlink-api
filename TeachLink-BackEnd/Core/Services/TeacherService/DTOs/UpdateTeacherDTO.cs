public record UpdateTeacherDTO
{
    public string full_name { get; init; }
    public string description { get; init; }
    public string mini_description { get; init; }
    public IEnumerable<SchoolSubjectDTO>? school_subjects { get; init; }
    public int experience { get; init; }
    public int degree { get; init; }
    public string educational_institution { get; init; }
    public int year_of_end { get; init; } = 0;
    public string city { get; init; }
    public int age { get; init; } = 18;
    public string sex { get; init; }
    public bool online { get; init; }
    public bool show_info { get; init; }
    public int price { get; init; } = 100;
}
