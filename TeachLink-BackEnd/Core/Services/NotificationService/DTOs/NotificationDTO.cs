public record NotificationDTO
{
    public required string id { get; init; }

    public required string id_teacher { get; init; }

    public required string id_student { get; init; }

    public required bool is_read { get; init; }

    public required bool for_teacher { get; init; }
    public required DateTime createdAt { get; init; }

    public required DateTime updatedAt { get; init; }
}
