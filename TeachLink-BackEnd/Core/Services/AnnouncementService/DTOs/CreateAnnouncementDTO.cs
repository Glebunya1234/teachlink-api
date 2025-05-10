using TeachLink_BackEnd.Core.ModelsMDB;

public record CreateAnnouncementDTO
{
    public required string id_student { get; init; }

    public required string mini_description { get; init; }

    public IEnumerable<SchoolSubjectDTO> school_subjects { get; init; }

    public required string description { get; init; }
}
