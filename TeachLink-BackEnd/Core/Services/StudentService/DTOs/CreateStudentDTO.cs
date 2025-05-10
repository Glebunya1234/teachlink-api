public record CreateStudentDTO
{
    public required string full_name { get; init; }
    public required string email { get; init; }
    public required string uid { get; set; }
}
