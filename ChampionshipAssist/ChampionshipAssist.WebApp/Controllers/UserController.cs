using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace ChampionshipAssist.WebApp.Controllers
{
    public sealed partial class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<User> _usersRepository;
        private readonly UserManager<User> _userManager;

        public UserController(IRepository<User> usersRepository,
            UserManager<User> userManager,
            ILogger<HomeController> logger)
        {
            _usersRepository = usersRepository;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index() =>
            View(await _usersRepository.GetAllEntitiesAsync());

        public async Task<IActionResult> Details(string id)
        {
            var user = await _usersRepository.GetEntityByIdAsync(id);

            if (user == null)
            {
                // Log or handle the case where the tournament is not found
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Create()
        {
            PopulateDropdowns();
            return View();
        }

        public async Task<IActionResult> Update(string id)
        {
            PopulateDropdowns();

            var user = await _usersRepository.GetEntityByIdAsync(id);
            var dto = new UserDto()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
            };
            return View(dto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _usersRepository.GetEntityByIdAsync(id);

            return View(new UserDto()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto dto)
        {
            var user = new User
            {
                UserName = dto.Name,
                Email = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var passwordHasher = new PasswordHasher<User>();

            user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);

            await _userManager.CreateAsync(user);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns();
                return View(dto);
            }

            var user = await _usersRepository.GetEntityByIdAsync(dto.Id);
            if (user is null)
                return NotFound();

            user.UserName = dto.Name;
            user.Email = dto.Email;

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserDto dto)
        {
            if (!Guid.TryParse(dto.Id.ToString(), out var id)) return View(dto);

            var user = await _usersRepository.GetEntityByIdAsync(id.ToString());
            if (user is null)
                return NotFound();

            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }

        private void PopulateDropdowns()
        {
            ViewData["Users"] = new SelectList(
                _usersRepository.GetAllEntities(),
                nameof(Core.Entities.User.Id),
                nameof(Core.Entities.User.UserName));
        }
    }
}