using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChampionshipAssist.WebApp.Controllers
{
    [Route("api/TournamentApi")]
    [ApiController]
    public class TournamentApiController : ControllerBase
    {
        private readonly IRepository<Tournament> _tournamentRepository;

        public TournamentApiController(IRepository<Tournament> tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        // GET: api/TournamentApi
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine("Executing GetAll action...");
            var tournaments = await _tournamentRepository.GetAllEntitiesAsync();
            Console.WriteLine($"Number of tournaments: {tournaments.Count}");
            return Ok(tournaments);
        }

        // GET: api/TournamentApi/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var tournament = await _tournamentRepository.GetEntityByIdAsync(id);
            if (tournament == null)
                return NotFound();

            return Ok(tournament);
        }

        // POST: api/TournamentApi
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TournamentDto tournamentDto)
        {
            if (string.IsNullOrWhiteSpace(tournamentDto.Name))
                return BadRequest("Name is required.");

            var tournament = new Tournament
            {
                Id = tournamentDto.Id,
                Name = tournamentDto.Name,
                StartDate = tournamentDto.StartDate,
                EndDate = tournamentDto.EndDate,
                Game = tournamentDto.Game,
                Rules = tournamentDto.Rules,
                ShortDesc = tournamentDto.ShortDesc,
                LongDesc = tournamentDto.LongDesc,
                IsPrivate = tournamentDto.IsPrivate,
                IsOpenToCybersportsmen = tournamentDto.IsOpenToCybersportsmen,
                IsOpenToUsers = tournamentDto.IsOpenToUsers,
                VACBannedParticipantsAllowed = tournamentDto.VACBannedParticipantsAllowed,
                OrganizerId = tournamentDto.OrganizerId,
                OrganizerName = tournamentDto.OrganizerName
            };
            await _tournamentRepository.AddNewEntityAsync(tournament);

            return CreatedAtAction(nameof(Get), new { id = tournament.Id }, tournament);
        }

        // PUT: api/TournamentApi/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TournamentDto tournamentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tournament = await _tournamentRepository.GetEntityByIdAsync(id);
            if (tournament == null)
                return NotFound();

            tournament.Name = tournamentDto.Name;
            tournament.StartDate = tournamentDto.StartDate;
            tournament.EndDate = tournamentDto.EndDate;
            tournament.Game = tournamentDto.Game;
            tournament.Rules = tournamentDto.Rules;
            tournament.ShortDesc = tournamentDto.ShortDesc;
            tournament.LongDesc = tournamentDto.LongDesc;
            tournament.IsPrivate = tournamentDto.IsPrivate;
            tournament.IsOpenToCybersportsmen = tournamentDto.IsOpenToCybersportsmen;
            tournament.IsOpenToUsers = tournamentDto.IsOpenToUsers;
            tournament.VACBannedParticipantsAllowed = tournamentDto.VACBannedParticipantsAllowed;
            tournament.OrganizerId = tournamentDto.OrganizerId;
            tournament.OrganizerName = tournamentDto.OrganizerName;

            _tournamentRepository.UpdateExistingEntity(tournament);

            return Ok(tournament);
        }

        // DELETE: api/TournamentApi/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var tournament = await _tournamentRepository.GetEntityByIdAsync(id);
            if (tournament == null)
                return NotFound();

            _tournamentRepository.RemoveExistingEntity(tournament);
            return NoContent();
        }
    }
}