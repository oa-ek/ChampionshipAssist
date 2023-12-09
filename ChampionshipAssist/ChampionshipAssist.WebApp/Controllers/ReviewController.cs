using ChampionshipAssist.Core.Context;
using ChampionshipAssist.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.WebApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ChampionsshipAssistDbContext _context;

        public ReviewController(ChampionsshipAssistDbContext context)
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
        public async Task<IActionResult> Create(Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // Операція читання (список всіх турнірів)
        public async Task<IActionResult> Index()
        {
            var reviews = await _context.Reviews.ToListAsync();
            return View(reviews);
        }

        // Операція читання (інформація про конкретний турнір)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FirstOrDefaultAsync(t => t.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // Операція оновлення
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FirstOrDefaultAsync(t => t.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Review review)
        {
            if (id != review.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewId))
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
            return View(review);
        }

        // Операція видалення
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FirstOrDefaultAsync(t => t.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(t => t.ReviewId == id);
        }
    }
}