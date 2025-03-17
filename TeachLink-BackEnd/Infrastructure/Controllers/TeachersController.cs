using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.Models;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly TeachersService _teachersService;

        public TeachersController(TeachersService teachersService)
        {
            _teachersService = teachersService;
        }

        [HttpGet("/teachers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeacherTileDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(int offset, int limit)
        {
            var teacherListResponseDTO = await _teachersService.GetAll(offset, limit);
            return Ok(teacherListResponseDTO);
        }

        [HttpGet("/teacher/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherTileDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var teacherTileDto = await _teachersService.GetById(id);

            return Ok(teacherTileDto);
        }

        [HttpPost("/teachers")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateTeacherDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateTeacherDTO teacherDto)
        {
            await _teachersService.Create(teacherDto);
            return Ok();
        }

        [HttpPatch("/teachers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateTeacherDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTeacherDTO teacherDto)
        {
            await _teachersService.Update(id, teacherDto);
            return Ok(teacherDto);
        }
    }
}
