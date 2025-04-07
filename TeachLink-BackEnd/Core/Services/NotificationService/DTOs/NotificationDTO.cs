public record NotificationDTO
{
    public required string id { get; init; }

    public TeacherTileDTO id_teacher { get; init; }

    public StudentDTO id_student { get; init; }

    public bool is_read { get; init; }

    public bool for_teacher { get; init; }
    public DateTime createdAt { get; init; }

    public DateTime updatedAt { get; init; }
}
