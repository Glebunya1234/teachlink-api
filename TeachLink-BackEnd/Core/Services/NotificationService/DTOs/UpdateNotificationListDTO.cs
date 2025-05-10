public record UpdateNotificationListDTO
{
    public required List<string> ids { get; init; }
 
    public required bool is_read { get; init; }
}
