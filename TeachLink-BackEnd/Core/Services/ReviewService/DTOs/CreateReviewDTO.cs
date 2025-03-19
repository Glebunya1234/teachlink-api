public record CreateReviewDTO
{
    public required Guid id { get; init; }

    public required string reviews_text { get; init; }

    public required SchoolSubjectListDTO school_subjects { get; init; }

    public required int rating { get; init; }
}
