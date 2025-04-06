using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TeachersController : ControllerBase
    {
        private readonly TeachersService _teachersService;

        public TeachersController(TeachersService teachersService)
        {
            _teachersService = teachersService;
        }

        [HttpGet("teachers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeacherTileDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 20,
            [FromQuery] SortByEnumMDB? sortBy = null,
            [FromQuery] string? subjects = null,
            [FromQuery] bool? isOnline = null,
            [FromQuery] string? city = null,
            [FromQuery] int? minPrice = null,
            [FromQuery] int? maxPrice = null
        )
        {
            var teacherListResponseDTO = await _teachersService.GetAll(
                offset,
                limit,
                sortBy,
                subjects,
                isOnline,
                city,
                minPrice,
                maxPrice
            );
            return Ok(teacherListResponseDTO);
        }

        [HttpGet("teachers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FullTeacherTileDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            var teacherTileDto = await _teachersService.GetById(id);

            return Ok(teacherTileDto);
        }

        [HttpPost("teachers")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateTeacherDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateTeacherDTO teacherDto)
        {
            await _teachersService.Create(teacherDto);
            return Ok();
        }

        [HttpPatch("teachers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateTeacherDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateTeacherDTO teacherDto)
        {
            await _teachersService.Update(id, teacherDto);
            return Ok(teacherDto);
        }
    }
}
