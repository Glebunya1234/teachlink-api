public record CreateReviewDTO
{
    public required Guid id { get; init; }
    public required Guid id_teacher { get; init; }
    public required Guid id_student { get; init; }
    public required string reviews_text { get; init; }
    public IEnumerable<SchoolSubjectDTO> school_subjects { get; init; }
    public required int rating { get; init; }
}
