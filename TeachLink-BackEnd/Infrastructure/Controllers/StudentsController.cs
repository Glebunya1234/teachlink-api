using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.Services.StudentService;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsService _studentsService;
        private readonly ImagesService _gridFsService;

        public StudentsController(StudentsService studentsService, ImagesService gridFsService)
        {
            _studentsService = studentsService;
            _gridFsService = gridFsService;
        }

        [HttpGet("students")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(int offset, int limit)
        {
            var studentListResponseDTO = await _studentsService.GetAll(offset, limit);
            return Ok(studentListResponseDTO);
        }

        [HttpGet("students/{uid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string uid)
        {
            var studentDTO = await _studentsService.GetById(uid);

            return Ok(studentDTO);
        }

        [Authorize]
        [HttpPost("students")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateTeacherDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateStudentDTO createStudentDTO)
        {
            await _studentsService.Create(createStudentDTO);
            return Ok();
        }

        [Authorize]
        [HttpPatch("students/{uid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateStudentDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(
            string uid,
            [FromBody] UpdateStudentDTO updateStudentDTO
        )
        {
            await _studentsService.Update(uid, updateStudentDTO);
            return Ok(updateStudentDTO);
        }
    }
}
