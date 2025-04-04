public record ReviewDTO
{
    public required string id { get; init; }

    public required string id_teachers { get; init; }

    public required string id_students { get; init; }

    public required string reviews_text { get; init; }

    public required IEnumerable<SchoolSubjectDTO> school_subjects { get; init; }

    public required int rating { get; init; }

    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
