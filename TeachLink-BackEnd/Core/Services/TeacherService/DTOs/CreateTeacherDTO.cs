using TeachLink_BackEnd.Core.Models;

public record CreateTeacherDTO
{
    public string? full_name { get; init; }
    public string? description { get; init; }
    public string? mini_description { get; init; }
    public IEnumerable<SchoolSubjectDTO>? school_subjects { get; init; }
    public string? experience { get; init; }
    public string? degree { get; init; }
    public string? educational_institution { get; init; }
    public int? year_of_end { get; init; }
    public string? city { get; init; }
    public int? age { get; init; }
    public string? sex { get; init; }
    public bool? online { get; init; }
    public bool? show_info { get; init; }
    public int? price { get; init; }
}
