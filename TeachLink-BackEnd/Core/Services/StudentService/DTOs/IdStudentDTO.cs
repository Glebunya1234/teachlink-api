public record IdStudentDTO
{
    public required int id { get; init; }

    public required int full_name { get; init; }

    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
