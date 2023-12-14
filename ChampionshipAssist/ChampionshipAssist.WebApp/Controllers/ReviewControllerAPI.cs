using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChampionshipAssist.WebApp.Controllers
{
	public class ReviewControllerAPI
	{
		[Route("api/[controller]")]
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
				return Ok(await _reviewRepository.GetAllEntitiesAsync());
			}

			// GET: api/ReviewApi/{id}
			[HttpGet("{id}")]
			public async Task<IActionResult> Get(Guid id)
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
				if (string.IsNullOrWhiteSpace(reviewDto.UserId))
					return BadRequest("Writer's ID is required.");

				var review = new Review
				{
					UserId = reviewDto.UserId
				};
				await _reviewRepository.AddNewEntityAsync(review);

				return CreatedAtAction(nameof(Get), new { id = review.Id }, review);
			}

			// PUT: api/ReviewApi/{id}
			[HttpPut("{id}")]
			public async Task<IActionResult> Update(Guid id, [FromBody] ReviewDto reviewDto)
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var review = await _reviewRepository.GetEntityByIdAsync(id);
				if (review == null)
					return NotFound();

				review.Id = reviewDto.Id;
				_reviewRepository.UpdateExistingEntity(review);

				return NoContent();
			}

			// DELETE: api/ReviewApi/{id}
			[HttpDelete("{id}")]
			public async Task<IActionResult> Delete(Guid id)
			{
				var review = await _reviewRepository.GetEntityByIdAsync(id);
				if (review == null)
					return NotFound();

				_reviewRepository.RemoveExistingEntity(review);
				return NoContent();
			}
		}
	}
}
