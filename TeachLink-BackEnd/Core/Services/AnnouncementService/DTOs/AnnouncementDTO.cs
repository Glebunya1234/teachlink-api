public record AnnouncementDTO
{
    public required string id { get; init; }

    public required string id_students { get; init; }

    public required string mini_description { get; init; }

    public required IEnumerable<SchoolSubjectDTO> school_subjects { get; init; }

    public required string description { get; init; }

    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
