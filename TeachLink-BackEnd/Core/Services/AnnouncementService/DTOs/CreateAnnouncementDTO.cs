using TeachLink_BackEnd.Core.Models;

public record CreateAnnouncementDTO
{
    public required Guid id { get; init; }

    public Guid id_student { get; init; }

    public string mini_description { get; init; }

    public IEnumerable<SchoolSubjectsModel> school_subjects { get; init; }

    public string description { get; init; }
}
