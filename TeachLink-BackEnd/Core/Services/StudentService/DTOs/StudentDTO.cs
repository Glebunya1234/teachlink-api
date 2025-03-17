public record StudentDTO
{
    public required int id { get; init; }
    public string full_name { get; init; }
    public string city { get; init; }
    public int age { get; init; }
    public string sex { get; init; }
    public required DateTime createdAt { get; init; }
    public required DateTime updatedAt { get; init; }
}
