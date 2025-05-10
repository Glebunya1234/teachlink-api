using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Services.StudentService;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationsController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("notifications")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NotificationDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([Required] string id_entity, [Required] bool for_teacher)
        {
            CheckAuthHelper.GetTokenFromHeader(HttpContext.Request);

            var notificationDTO = await _notificationService.GetAll(id_entity, for_teacher);
            return Ok(notificationDTO);
        }

        [HttpGet("notifications/id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([Required, FromQuery] string id)
        {
            CheckAuthHelper.GetTokenFromHeader(HttpContext.Request);

            var notificationDTO = await _notificationService.GetById(id);
            return Ok(notificationDTO);
        }

        [HttpPost("notifications")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateNotificationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(
            [FromBody] CreateNotificationDTO createNotificationDTO
        )
        {
            CheckAuthHelper.GetTokenFromHeader(HttpContext.Request);

            await _notificationService.Create(createNotificationDTO);
            return Created();
        }

        [HttpPatch("notifications/id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateNotificationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(
            [Required, FromQuery] string id,
            [Required, FromBody] UpdateNotificationDTO updateNotificationDTO
        )
        {
            CheckAuthHelper.GetTokenFromHeader(HttpContext.Request);

            await _notificationService.Update(id, updateNotificationDTO);
            return Ok();
        }


        [HttpPatch("notifications/ids")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateNotificationListDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateByIds(
          
          [Required, FromBody] UpdateNotificationListDTO updateNotificationListDTO
      )
        {
            CheckAuthHelper.GetTokenFromHeader(HttpContext.Request);

            await _notificationService.UpdateMany(updateNotificationListDTO);
            return Ok();
        }
    }
}
