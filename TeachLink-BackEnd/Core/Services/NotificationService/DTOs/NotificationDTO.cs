public record NotificationDTO
{
    public required string id { get; init; }

    public IdTeacherDTO id_teacher { get; set; }

    public IdStudentDTO id_student { get; set; }

    public bool is_read { get; set; }

    public bool for_teacher { get; set; }
    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
