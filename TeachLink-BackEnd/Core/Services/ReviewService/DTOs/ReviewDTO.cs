public record ReviewDTO
{
    public required string id { get; init; }

    public required TeacherTileDTO id_teachers { get; init; }

    public required StudentDTO id_students { get; init; }

    public required string reviews_text { get; init; }

    public required IEnumerable<SchoolSubjectDTO> school_subjects { get; init; }

    public required int rating { get; init; }

    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
