public record ReviewDTO
{
    public required Guid id { get; init; }

    public required IdTeacherDTO id_teachers { get; init; }

    public required IdStudentDTO id_students { get; init; }

    public required string reviews_text { get; init; }

    public required SchoolSubjectListDTO school_subjects { get; init; }

    public required int rating { get; init; }
    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
