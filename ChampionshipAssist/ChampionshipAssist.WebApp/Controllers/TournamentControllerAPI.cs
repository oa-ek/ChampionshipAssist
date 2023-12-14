using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChampionshipAssist.WebApp.Controllers
{
	public class TournamentControllerAPI
	{
		[Route("api/[controller]")]
		[ApiController]
		public class TournamentApiController : ControllerBase
		{
			private readonly IRepository<Tournament> _tournamentRepository;

			public TournamentApiController(IRepository<Tournament> tournamentsRepository)
			{
				_tournamentRepository = tournamentsRepository;
			}

			// GET: api/TournamentApi
			[HttpGet]
			public async Task<IActionResult> GetAll()
			{
				return Ok(await _tournamentRepository.GetAllEntitiesAsync());
			}

			// GET: api/TournamentApi/{id}
			[HttpGet("{id}")]
			public async Task<IActionResult> Get(Guid id)
			{
				var tournament = await _tournamentRepository.GetEntityByIdAsync(id);
				if (tournament == null)
					return NotFound();

				return Ok(tournament);
			}

			// POST: api/ReivewApi
			[HttpPost]
			public async Task<IActionResult> Create([FromBody] TournamentDto tournamentDto)
			{
				if (string.IsNullOrWhiteSpace(tournamentDto.Name))
					return BadRequest("Tournament name is required.");

				var tournament = new Tournament
				{
					Name = tournamentDto.Name
				};
				await _tournamentRepository.AddNewEntityAsync(tournament);

				return CreatedAtAction(nameof(Get), new { id = tournament.Id }, tournament);
			}

			// PUT: api/TournamentApi/{id}
			[HttpPut("{id}")]
			public async Task<IActionResult> Update(Guid id, [FromBody] TournamentDto tournamentDto)
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var tournament = await _tournamentRepository.GetEntityByIdAsync(id);
				if (tournament == null)
					return NotFound();

				tournament.Name = tournamentDto.Name;
				_tournamentRepository.UpdateExistingEntity(tournament);

				return NoContent();
			}

			// DELETE: api/TournamentApi/{id}
			[HttpDelete("{id}")]
			public async Task<IActionResult> Delete(Guid id)
			{
				var tournament = await _tournamentRepository.GetEntityByIdAsync(id);
				if (tournament == null)
					return NotFound();

				_tournamentRepository.RemoveExistingEntity(tournament);
				return NoContent();
			}
		}
	}
}
