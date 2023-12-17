using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChampionshipAssist.WebApp.Controllers
{
		[Route("api/ReviewApi")]
		[ApiController]
		public class ReviewApiController : ControllerBase
		{
			private readonly IRepository<Review> _reviewRepository;

			public ReviewApiController(IRepository<Review> reviewsRepository)
			{
				_reviewRepository = reviewsRepository;
			}

			// GET: api/ReviewApi
			[HttpGet]
			public async Task<IActionResult> GetAll()
			{
                Console.WriteLine("Executing GetAll action...");
                var reviews = await _reviewRepository.GetAllEntitiesAsync();
                Console.WriteLine($"Number of reviews: {reviews.Count}");
                return Ok(reviews);
            }

			// GET: api/ReviewApi/{id}
			[HttpGet("{id}")]
			public async Task<IActionResult> Get(string id)
			{
				var review = await _reviewRepository.GetEntityByIdAsync(id);
				if (review == null)
					return NotFound();

				return Ok(review);
			}

			// POST: api/ReivewApi
			[HttpPost]
			public async Task<IActionResult> Create([FromBody] ReviewDto reviewDto)
			{
				if (string.IsNullOrWhiteSpace(reviewDto.Id.ToString()))
					return BadRequest("ID is required.");

				var review = new Review
				{
					Id = reviewDto.Id,
					UserId = reviewDto.UserId,
					TournamentId = reviewDto.TournamentId,
					Rating = reviewDto.Rating,
					Commentary = reviewDto.Commentary
				};
				await _reviewRepository.AddNewEntityAsync(review);

				return CreatedAtAction(nameof(Get), new { id = review.Id }, review);
			}

        // PUT: api/ReviewApi/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ReviewDto reviewDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var review = await _reviewRepository.GetEntityByIdAsync(id);
            if (review == null)
                return NotFound();

            review.UserId = reviewDto.UserId;
            review.TournamentId = reviewDto.TournamentId;
            review.Rating = reviewDto.Rating;
            review.Commentary = reviewDto.Commentary;

            _reviewRepository.UpdateExistingEntity(review);

            return Ok(review);
        }

        // DELETE: api/ReviewApi/{id}
        [HttpDelete("{id}")]
			public async Task<IActionResult> Delete(string id)
			{
				var review = await _reviewRepository.GetEntityByIdAsync(id);
				if (review == null)
					return NotFound();

				_reviewRepository.RemoveExistingEntity(review);
				return NoContent();
			}
		}
}
