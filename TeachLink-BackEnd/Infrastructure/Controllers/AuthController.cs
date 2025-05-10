
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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

        

        [HttpGet("IsChekedRole/{uid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string uid)
        {


            var origin = HttpContext.Request.Headers["Origin"].FirstOrDefault();

            var DTO = await _authService.GetById(uid);
            return Ok(DTO);
        }
               
    }
}
