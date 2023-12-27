using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChampionshipAssist.WebApp.Views.Review
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Core.Entities.Review> _reviewRepository;

        public CreateModel(IRepository<Core.Entities.Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [BindProperty]
        public Core.Entities.Review Review { get; set; }

        public IActionResult OnGet()
        {
            // Handle GET request if needed
            ViewData["Message"] = "This is the SubmitReview page.";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return to the page with validation errors
                return Page();
            }

            Review.Id = Guid.NewGuid().ToString();

            // Add the new review to the repository
            await _reviewRepository.AddNewEntityAsync(Review);

            // Redirect back to the tournament details page
            return RedirectToPage("/Tournament/Details", new { id = Review.TournamentId });
        }
    }
}