using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChampionshipAssist.WebApp.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentRepository tournamentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TournamentController(ITournamentRepository tournamentRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.tournamentRepository = tournamentRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(tournamentRepository.GetAll());
        }

        [Authorize(Roles = "User")]
        public IActionResult My()
        {
            return View(tournamentRepository.GetAll(User.Identity.Name));
        }

        /*public string Image(int id)
        {
            var course = courseRepository.Get(id);
            return course.CoverPath;
        }*/

        [Authorize]
        public IActionResult Create()
        {
            return View(new Tournament());
        }

        [AllowAnonymous]
        public IActionResult Create1()
        {
            return View(new Tournament());
        }


        [HttpPost]
        [Authorize]
        public IActionResult Create(Tournament model)
        {
            if (ModelState.IsValid)
            {
                tournamentRepository.Add(model, User.Identity.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Details(string id)
        {
            return View(tournamentRepository.Get(id));
        }
    }
}