public record StudentDTO
{
    public required string id { get; init; }
    public required string uid { get; set; }
    public string full_name { get; init; }
    public string city { get; init; }
    public int age { get; init; }
    public string sex { get; init; }
    public string phone_number { get; init; }
    public required DateTime createdAt { get; init; }
    public required DateTime updatedAt { get; init; }
}
