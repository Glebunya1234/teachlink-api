public record CreateNotificationDTO
{
    public required string id_teacher { get; set; }

    public required string id_student { get; set; }

    public required bool is_read { get; set; }

    public required bool for_teacher { get; set; }
}
