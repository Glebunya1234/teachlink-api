using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.Services.ImageService.DTOs;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ImagesController : ControllerBase
    {
        private readonly ImagesService _gridFsService;

        public ImagesController(ImagesService gridFsService)
        {
            _gridFsService = gridFsService;
        }

        [HttpGet("images/{avatar_id}/avatar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAvatar(string avatar_id)
        {
            var stream = await _gridFsService.DownloadFileAsync(avatar_id);
            return File(stream, "image/png");
        }

        [Authorize]
        [HttpPatch("images")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateImagesDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAvatar([FromForm] UpdateImagesDTO updateImagesDTO)
        {
            await _gridFsService.UploadFileAsync(updateImagesDTO);
            return Ok(updateImagesDTO);
        }

        [Authorize]
        [HttpDelete("images")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(DeleteImagesDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAvatar([FromBody] DeleteImagesDTO deleteImagesDTO)
        {
            await _gridFsService.RemoveUserAvatarAsync(deleteImagesDTO);
            return NoContent();
        }
    }
}
