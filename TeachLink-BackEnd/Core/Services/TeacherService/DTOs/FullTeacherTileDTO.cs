using TeachLink_BackEnd.Core.Models;

public record FullTeacherTileDTO
{
    public required Guid id { get; init; }
    public string full_name { get; init; }
    public string description { get; init; }
    public string mini_description { get; init; }
    public IEnumerable<SchoolSubjectDTO> school_subjects { get; init; }
    public ExperienceDTO experience { get; init; }
    public DegreeDTO degree { get; init; }
    public string educational_institution { get; init; }
    public int year_of_end { get; init; }
    public string city { get; init; }
    public int age { get; init; }
    public string sex { get; init; }
    public bool online { get; init; }
    public required bool show_info { get; init; }
    public int price { get; init; }

    //public required DateTime createdAt { get; init; }

    //public required DateTime updatedAt { get; init; }
}
