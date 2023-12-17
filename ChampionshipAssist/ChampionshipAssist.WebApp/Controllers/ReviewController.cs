using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChampionshipAssist.WebApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IRepository<Review> reviewRepository;

        public ReviewController(IRepository<Review> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        public async Task<IActionResult> Index() =>
        View(await reviewRepository.GetAllEntitiesAsync());

        public async Task<IActionResult> Update(string id)
        {
            PopulateDropdowns();

            var review = await reviewRepository.GetEntityByIdAsync(id);

            return View(new ReviewDto
            {
                Id = review.Id,
                UserId = review.UserId
            });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var review = await reviewRepository.GetEntityByIdAsync(id);

            return View(new ReviewDto
            {
                Id = review.Id,
                UserId = review.UserId
            });
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ReviewDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserId.ToString())
                || string.IsNullOrEmpty(dto.UserId.ToString()))
                return View(dto);

            await reviewRepository.AddNewEntityAsync(new Review
            {
                UserId = dto.UserId
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ReviewDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var review = await reviewRepository.GetEntityByIdAsync(dto.Id);
            if (review is null)
                return NotFound();

            review.UserId = dto.UserId;
            reviewRepository.UpdateExistingEntity(review);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReviewDto dto)
        {
            if (!Guid.TryParse(dto.Id.ToString(), out var id)) return View(dto);

            var review = await reviewRepository.GetEntityByIdAsync(id.ToString());
            if (review is null)
                return NotFound();

            reviewRepository.RemoveExistingEntity(review);
            return RedirectToAction("Index");
        }

        private void PopulateDropdowns()
        {
            ViewData["Tags"] = new SelectList(
                reviewRepository.GetAllEntities(),
                nameof(Review.Id),
                nameof(Review.UserId));
        }
    }
}