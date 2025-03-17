public record CreateStudentDTO
{
    public required int id { get; init; }
    public string full_name { get; init; }
    public string city { get; init; }
    public int age { get; init; }
    public string sex { get; init; }
}
