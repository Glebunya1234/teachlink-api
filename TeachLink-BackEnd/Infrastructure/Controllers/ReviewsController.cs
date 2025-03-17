using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.Services.StudentService;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewsService _reviewsService;

        public ReviewsController(ReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [HttpGet("/reviews")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(int id_teacher, int offset, int limit)
        {
            var reviewListResponseDTO = await _reviewsService.GetAll(id_teacher, offset, limit);
            return Ok(reviewListResponseDTO);
        }

        [HttpGet("/review/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReviewDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id_teacher, int id_student)
        {
            var reviewDTO = await _reviewsService.GetById(id_teacher, id_student);

            return Ok(reviewDTO);
        }

        [HttpPost("/review")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateReviewDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(
            int id_teacher,
            int id_student,
            [FromBody] CreateReviewDTO createReviewDTO
        )
        {
            await _reviewsService.Create(id_teacher, id_student, createReviewDTO);
            return Created();
        }

        [HttpPatch("/review/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateReviewDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(
            int id_teacher,
            int id_student,
            [FromBody] UpdateReviewDTO updateReview
        )
        {
            await _reviewsService.Update(id_teacher, id_student, updateReview);
            return Ok();
        }
    }
}
