public record SubjectDTO
{
    public required string id { get; init; }
    public required string subject { get; init; }
    public required DateTime createdAt { get; init; }
    public required DateTime updatedAt { get; init; }
}
