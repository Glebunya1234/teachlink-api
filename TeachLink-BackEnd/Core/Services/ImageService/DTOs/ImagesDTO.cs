namespace TeachLink_BackEnd.Core.Services.ImageService.DTOs
{
    public record ImagesDTO
    {
        public required string uid { get; init; }
        public required bool for_teacher { get; init; }
    }
}
