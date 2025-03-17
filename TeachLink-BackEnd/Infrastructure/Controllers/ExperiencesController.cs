using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.Services.StudentService;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperiencesController : ControllerBase
    {
        private readonly ExperienceService _experienceService;

        public ExperiencesController(ExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpGet("/experiences")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ExperienceDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var experienceDTO = await _experienceService.GetAll();
            return Ok(experienceDTO);
        }

        [HttpGet("/experience/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExperienceDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var experienceDTO = await _experienceService.GetById(id);

            return Ok(experienceDTO);
        }
    }
}
