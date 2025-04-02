public record IdDegreeDTO
{
    public required Guid id { get; init; }
    public required string degree_name { get; init; }
    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
