public record UpdateAnnouncementDTO
{
    public string? mini_description { get; init; }

    public IEnumerable<SchoolSubjectDTO>? school_subjects { get; init; }

    public string? description { get; init; }
}
