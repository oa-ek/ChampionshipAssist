using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChampionshipAssist.WebApp.Controllers
{
    public class TournamentController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IRepository<Tournament> tournamentRepository;
        private readonly IRepository<User> userRepository;

        public TournamentController(UserManager<User> userManager, IRepository<Tournament> tournamentRepository, IRepository<User> userRepository)
        {
            this.userManager = userManager;
            this.tournamentRepository = tournamentRepository;
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> Index() =>
        View(await tournamentRepository.GetAllEntitiesAsync());

        public async Task<IActionResult> Details(string id)
        {
            var tournament = await tournamentRepository.GetEntityByIdAsync(id);

            if (tournament == null)
            {
                // Log or handle the case where the tournament is not found
                return NotFound();
            }

            return View(tournament);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            var tournament = await tournamentRepository.GetEntityByIdAsync(id);

            if (tournament == null)
            {
                // Log or handle the case where the tournament is not found
                return NotFound();
            }

            return View(tournament);
        }

        public async Task<IActionResult> Participate(string tournamentId)
        {
            var tournament = await tournamentRepository.GetEntityByIdAsync(tournamentId);
            if (tournament == null)
            {
                return NotFound();
            }

            // Get the current user's ID
            var userId = userManager.GetUserId(User);

            var user = await userRepository.GetEntityByIdAsync(userId);
            if (user != null)
            {
                // Ensure that Participants collection is initialized
                if (tournament.Participants == null)
                {
                    tournament.Participants = new List<User>();
                }

                tournament.Participants.Add(user);
                await tournamentRepository.UpdateExistingEntityAsync(tournament);
            }

            return RedirectToAction("Details", new { id = tournamentId });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var tournament = await tournamentRepository.GetEntityByIdAsync(id);
            if (tournament == null)
                return NotFound();

            await tournamentRepository.RemoveExistingEntityAsync(tournament);

            return RedirectToPage("/Index");
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TournamentDto tournamentDto)
        {
            if (string.IsNullOrWhiteSpace(tournamentDto.Name)
                || string.IsNullOrEmpty(tournamentDto.Name))
                return View(tournamentDto);

            await tournamentRepository.AddNewEntityAsync(new Tournament
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
            });

            return RedirectToAction("Index");
        }

        [HttpPut("/Tournament/Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TournamentDto updatedTournamentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTournament = await tournamentRepository.GetEntityByIdAsync(id);
            if (existingTournament is null)
                return NotFound();

            // Update the existing tournament with the data from the request body
            existingTournament.Name = updatedTournamentDto.Name;
            existingTournament.StartDate = updatedTournamentDto.StartDate;
            existingTournament.EndDate = updatedTournamentDto.EndDate;
            existingTournament.Game = updatedTournamentDto.Game;
            existingTournament.Rules = updatedTournamentDto.Rules;
            existingTournament.ShortDesc = updatedTournamentDto.ShortDesc;
            existingTournament.LongDesc = updatedTournamentDto.LongDesc;
            existingTournament.IsPrivate = updatedTournamentDto.IsPrivate;
            existingTournament.IsOpenToCybersportsmen = updatedTournamentDto.IsOpenToCybersportsmen;
            existingTournament.IsOpenToUsers = updatedTournamentDto.IsOpenToUsers;
            existingTournament.VACBannedParticipantsAllowed = updatedTournamentDto.VACBannedParticipantsAllowed;
            existingTournament.OrganizerId = updatedTournamentDto.OrganizerId;
            existingTournament.OrganizerName = updatedTournamentDto.OrganizerName;

            await tournamentRepository.UpdateExistingEntityAsync(existingTournament);

            return NoContent(); // Indicates success with no response body
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TournamentDto dto)
        {
            if (!Guid.TryParse(dto.Id.ToString(), out var id)) return View(dto);

            var tournament = await tournamentRepository.GetEntityByIdAsync(id.ToString());
            if (tournament is null)
                return NotFound();

            await tournamentRepository.RemoveExistingEntityAsync(tournament);
            return RedirectToAction("Index");
        }
    }
}