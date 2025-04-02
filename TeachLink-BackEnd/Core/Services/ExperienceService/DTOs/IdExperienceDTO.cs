public record IdExperienceDTO
{
    public required Guid id { get; init; }
    public required string experience_name { get; init; }
    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
