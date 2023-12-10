using ChampionshipAssist.Core.Context; // Додайте простір імен для вашого контексту бази даних
using ChampionshipAssist.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChampionshipAssist.WebApp.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ChampionsshipAssistDbContext _context;

        public TournamentController(ChampionsshipAssistDbContext context)
        {
            _context = context;
        }

        // Операція створення
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _context.Tournaments.Add(tournament);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tournament);
        }

        // Операція читання (список всіх турнірів)
        public async Task<IActionResult> Index()
        {
            var tournaments = await _context.Tournaments.ToListAsync();
            return View(tournaments);
        }

        // Операція читання (інформація про конкретний турнір)
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // Операція оновлення
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournamentExists(tournament.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(tournament);
        }

        // Операція видалення
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TournamentExists(string id)
        {
            return _context.Tournaments.Any(t => t.Id == id);
        }
    }
}