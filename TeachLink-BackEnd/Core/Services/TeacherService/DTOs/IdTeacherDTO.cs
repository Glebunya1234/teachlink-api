public record IdTeacherDTO
{
    public required string id { get; init; }

    public required string full_name { get; init; }
    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
