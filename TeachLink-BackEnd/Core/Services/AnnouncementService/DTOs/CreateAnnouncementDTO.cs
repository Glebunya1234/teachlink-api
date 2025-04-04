using TeachLink_BackEnd.Core.Models;

public record CreateAnnouncementDTO
{
    public required string id { get; init; }

    public string id_student { get; init; }

    public string mini_description { get; init; }

    public IEnumerable<SchoolSubjectsModel> school_subjects { get; init; }

    public string description { get; init; }
}
