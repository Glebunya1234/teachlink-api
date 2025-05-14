public record UpdateStudentDTO
{
    public string? full_name { get; init; }
    public string? city { get; init; }
    public int? age { get; init; }
    public string? sex { get; init; }
    public string? phone_number { get; init; }
    public string? avatarId { get; init; }
}
