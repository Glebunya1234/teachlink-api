using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.Services.StudentService;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SubjectsController : ControllerBase
    {
        private readonly SubjectService _subjectService;

        public SubjectsController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("subjects")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SubjectDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var dTOs = await _subjectService.GetAll();
            return Ok(dTOs);
        }

        [HttpGet("subjects/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            var dTOs = await _subjectService.GetById(id);

            return Ok(dTOs);
        }
    }
}
