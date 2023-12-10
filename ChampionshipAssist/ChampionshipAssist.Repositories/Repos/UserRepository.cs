using ChampionshipAssist.Core.Context;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Repositories.DTOs.User;
using ChampionshipAssist.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.Repositories.Repos
{
    public class UserRepository : IUserRepository
    {
        private ChampionshipAssistDbContext _context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityUser> roleManager;

        public async Task<string> CreateAsync(UserCreateDto obj)
        {
            var newUser = new User
            {
                Email = obj.Email,
                UserName = obj.Name,
                SteamLink = obj.SteamLink,
                Documents = obj.Documents,
                NormalizedEmail = obj.Email.ToUpper(),
                NormalizedUserName = obj.Name.ToUpper(),
                EmailConfirmed = true
            };

            await userManager.CreateAsync(newUser, obj.Password);

            return _context.Users.First(x => x.Email == obj.Email).Id;
        }

        public async Task DeleteAsync(string id)
        {
            var user = _context.Users.Find(id);

            if ((await userManager.GetRolesAsync(user)).Any())
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            }
            await userManager.DeleteAsync(user);
        }

        public async Task<UserDto> GetAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var roles = await userManager.GetRolesAsync(user);
            return
                new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName,
                    SteamLink = user.SteamLink,
                    Bio = user.Bio,
                    IsConfirmed = user.EmailConfirmed,
                    Roles = roles.ToList()
                };
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var userIds = _context.Users.Select(x => x.Id).ToList();
            var usersDto = new List<UserDto>();

            foreach (var id in userIds)
                usersDto.Add(await GetAsync(id));

            return usersDto;
        }

        public async Task UpdateAsync(UserDto model, string[] roles)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (user.Email != model.Email)
            {
                user.Email = model.Email;
                user.UserName = model.Name;
                user.NormalizedUserName = model.Name.ToUpper();
                user.NormalizedEmail = model.Email.ToUpper();
            }

            if (user.SteamLink != model.SteamLink) user.SteamLink = model.SteamLink;
            if (user.EmailConfirmed != model.IsConfirmed) user.EmailConfirmed = model.IsConfirmed;

            if ((await userManager.GetRolesAsync(user)).Any())
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            }

            if (roles.Any())
            {
                await userManager.AddToRolesAsync(user, roles.ToList());
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string?>> GetRolesAsync()
        {
            return _context.Roles.Select(x => x.Name).ToList();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
