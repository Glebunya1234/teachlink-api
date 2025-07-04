﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Services.StudentService;

namespace TeachLink_BackEnd.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewsService _reviewsService;

        public ReviewsController(ReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [HttpGet("reviews/{id_teacher}")]
        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(PaginationResponse<ReviewDTO>)
        )]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(string id_teacher, int offset, int limit)
        {
            var reviewListResponseDTO = await _reviewsService.GetAll(id_teacher, offset, limit);
            return Ok(reviewListResponseDTO);
        }

        [HttpGet("reviews/{id_teacher}/{id_student}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReviewDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id_teacher, string id_student)
        {
            var reviewDTO = await _reviewsService.GetById(id_teacher, id_student);

            return Ok(reviewDTO);
        }

        [Authorize]
        [HttpPost("reviews")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateReviewDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateReviewDTO createReviewDTO)
        {
            await _reviewsService.Create(createReviewDTO);
            return Created();
        }

        [Authorize]
        [HttpPatch("reviews/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateReviewDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateReviewDTO updateReview)
        {
            await _reviewsService.Update(id, updateReview);
            return Ok(updateReview);
        }
    }
}
