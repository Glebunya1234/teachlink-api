public record UpdateReviewDTO
{
    public string? reviews_text { get; init; }

    public IEnumerable<SchoolSubjectDTO>? school_subjects { get; init; }

    public int? rating { get; init; }
}
