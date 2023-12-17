using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChampionshipAssist.WebApp.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IRepository<Tournament> tournamentRepository;

        public TournamentController(IRepository<Tournament> tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }
        public async Task<IActionResult> Index() =>
        View(await tournamentRepository.GetAllEntitiesAsync());

        public async Task<IActionResult> Update(string id)
        {
            PopulateDropdowns();

            var tournament = await tournamentRepository.GetEntityByIdAsync(id);

            return View(new TournamentDto
            {
                Id = tournament.Id,
                Name = tournament.Name
            });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var tournament = await tournamentRepository.GetEntityByIdAsync(id);

            return View(new TournamentDto
            {
                Id = tournament.Id,
                Name = tournament.Name
            });
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TournamentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name)
                || string.IsNullOrEmpty(dto.Name))
                return View(dto);

            await tournamentRepository.AddNewEntityAsync(new Tournament
            {
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(TournamentDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var tournament = await tournamentRepository.GetEntityByIdAsync(dto.Id);
            if (tournament is null)
                return NotFound();

            tournament.Name = dto.Name;
            tournamentRepository.UpdateExistingEntity(tournament);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TournamentDto dto)
        {
            if (!Guid.TryParse(dto.Id.ToString(), out var id)) return View(dto);

            var tournament = await tournamentRepository.GetEntityByIdAsync(id.ToString());
            if (tournament is null)
                return NotFound();

            tournamentRepository.RemoveExistingEntity(tournament);
            return RedirectToAction("Index");
        }

        private void PopulateDropdowns()
        {
            ViewData["Tags"] = new SelectList(
                tournamentRepository.GetAllEntities(),
                nameof(Tournament.Id),
                nameof(Tournament.Name));
        }
    }
}