using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChampionshipAssist.WebApp.Controllers
{
	public class UserControllerAPI
	{
		[Route("api/[controller]")]
		[ApiController]
		public class UserApiController : ControllerBase
		{
			private readonly IRepository<User> _userRepository;

			public UserApiController(IRepository<User> usersRepository)
			{
				_userRepository = usersRepository;
			}

			// GET: api/UserApi
			[HttpGet]
			public async Task<IActionResult> GetAll()
			{
				return Ok(await _userRepository.GetAllEntitiesAsync());
			}

			// GET: api/UserApi/{id}
			[HttpGet("{id}")]
			public async Task<IActionResult> Get(Guid id)
			{
				var user = await _userRepository.GetEntityByIdAsync(id);
				if (user == null)
					return NotFound();

				return Ok(user);
			}

			// POST: api/ReivewApi
			[HttpPost]
			public async Task<IActionResult> Create([FromBody] UserDto userDto)
			{
				if (string.IsNullOrWhiteSpace(userDto.Name))
					return BadRequest("User name is required.");

				var user = new User
				{
					Name = userDto.Name
				};
				await _userRepository.AddNewEntityAsync(user);

				return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
			}

			// PUT: api/UserApi/{id}
			[HttpPut("{id}")]
			public async Task<IActionResult> Update(Guid id, [FromBody] UserDto userDto)
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var user = await _userRepository.GetEntityByIdAsync(id);
				if (user == null)
					return NotFound();

				user.Name = userDto.Name;
				_userRepository.UpdateExistingEntity(user);

				return NoContent();
			}

			// DELETE: api/UserApi/{id}
			[HttpDelete("{id}")]
			public async Task<IActionResult> Delete(Guid id)
			{
				var user = await _userRepository.GetEntityByIdAsync(id);
				if (user == null)
					return NotFound();

				_userRepository.RemoveExistingEntity(user);
				return NoContent();
			}
		}
	}
}
