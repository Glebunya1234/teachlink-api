﻿namespace TeachLink_BackEnd.Core.Services.ImageService.DTOs
{
    public record DeleteImagesDTO
    {
        public required string avatar_id { get; init; }
        public required string uid { get; init; }
        public required bool for_teacher { get; init; }
    }
}
