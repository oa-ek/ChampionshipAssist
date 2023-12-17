using ChampionshipAssist.Application.DTOs;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChampionshipAssist.WebApp.Controllers
{
    [Route("api/UserApi")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserApiController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/UserApi
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine("Executing GetAll action...");
            var users = await _userRepository.GetAllEntitiesAsync();
            Console.WriteLine($"Number of users: {users.Count}");
            return Ok(users);
        }

        // GET: api/UserApi/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userRepository.GetEntityByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/UserApi
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.Id.ToString()))
                return BadRequest("ID is required.");

            var user = new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                SteamLink = userDto.SteamLink,
                Documents = userDto.Documents,
                Bio = userDto.Bio,
                IsBanned = userDto.IsBanned,
                IsVACBanned = userDto.IsVACBanned,
                BanDuration = userDto.BanDuration,
                BanCount = userDto.BanCount
            };
            await _userRepository.AddNewEntityAsync(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT: api/UserApi/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetEntityByIdAsync(id);
            if (user == null)
                return NotFound();

            user.Name = userDto.Name;
            user.SteamLink = userDto.SteamLink;
            user.Documents = userDto.Documents;
            user.Bio = userDto.Bio;
            user.IsBanned = userDto.IsBanned;
            user.IsVACBanned = userDto.IsVACBanned;
            user.BanDuration = userDto.BanDuration;
            user.BanCount = userDto.BanCount;

            _userRepository.UpdateExistingEntity(user);

            return Ok(user);
        }

        // DELETE: api/UserApi/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userRepository.GetEntityByIdAsync(id);
            if (user == null)
                return NotFound();

            _userRepository.RemoveExistingEntity(user);
            return NoContent();
        }
    }
}
