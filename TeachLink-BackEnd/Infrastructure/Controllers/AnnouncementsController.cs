using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.Services.StudentService;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly AnnouncementService _announcementService;

        public AnnouncementsController(AnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet("announcements")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AnnouncementDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(int offset, int limit)
        {
            var announcementDTO = await _announcementService.GetAll(offset, limit);
            return Ok(announcementDTO);
        }

        [Authorize]
        [HttpGet("announcements/list/student/{id_student}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnnouncementDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListById(string id_student)
        {
            var announcementDTO = await _announcementService.GetListById(id_student);

            return Ok(announcementDTO);
        }

        [HttpGet("announcements/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnnouncementDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            var announcementDTO = await _announcementService.GetById(id);

            return Ok(announcementDTO);
        }

        [Authorize]
        [HttpPost("announcements")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AnnouncementDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(
            [FromBody] CreateAnnouncementDTO createAnnouncementDTO
        )
        {
            await _announcementService.Create(createAnnouncementDTO);
            return Created();
        }

        [Authorize]
        [HttpPatch("announcements/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateAnnouncementDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(
            string id,
            [FromBody] UpdateAnnouncementDTO updateAnnouncementDTO
        )
        {
            await _announcementService.Update(id, updateAnnouncementDTO);
            return Ok();
        }

        [Authorize]
        [HttpDelete("announcements/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            await _announcementService.Delete(id);
            return NoContent();
        }
    }
}
