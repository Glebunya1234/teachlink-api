public record UpdateReviewDTO
{
    public required string reviews_text { get; init; }

    public required IEnumerable<SchoolSubjectDTO> school_subjects { get; init; }

    public required int rating { get; init; }
}
