namespace TeachLink_BackEnd.Core.Services.ImageService.DTOs
{
    public record UpdateImagesDTO
    {
        public required string uid { get; init; }
        public required bool for_teacher { get; init; }
        public required IFormFile avatarFile { get; init; }
    }
}
