using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.Services.StudentService;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DegreesController : ControllerBase
    {
        private readonly DegreeService _degreeService;

        public DegreesController(DegreeService degreeService)
        {
            _degreeService = degreeService;
        }

        [HttpGet("/degrees")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DegreeDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var degreeDTO = await _degreeService.GetAll();
            return Ok(degreeDTO);
        }

        [HttpGet("/degree/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DegreeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var degreeDTO = await _degreeService.GetById(id);

            return Ok(degreeDTO);
        }
    }
}
