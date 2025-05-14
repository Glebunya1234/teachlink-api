public record TeacherTileDTO
{
    public required string id { get; init; }
    public required string uid { get; init; }
    public required string full_name { get; init; }
    public required string email { get; init; }
    public string mini_description { get; init; }
    public IEnumerable<SchoolSubjectDTO> school_subjects { get; init; }
    public string? avatarId { get; set; }
    public string? avatarUrl { get; set; }
    public string experience { get; init; }
    public string degree { get; init; }
    public string educational_institution { get; init; }
    public bool online { get; init; }
    public int price { get; init; }
    public bool show_info { get; init; }
    public required string phone_number { get; init; }
    public string city { get; init; }
    public int age { get; init; }
    public int review_count { get; init; }
    public decimal average_rating { get; init; }
    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
