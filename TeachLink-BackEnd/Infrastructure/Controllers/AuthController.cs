
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Services.StudentService;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    
    [ApiController]
    [Route("api/")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        

        [HttpGet("IsChekedRole/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            

            var DTO = await _authService.GetById(id);
            return Ok(DTO);
        }
               
    }
}
