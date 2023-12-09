using ChampionshipAssist.Repositories.DTOs.User;

namespace ChampionshipAssist.Repositories.Interfaces
{
    public interface IUserRepository : ISave
    {
        Task<UserDto> GetAsync(string id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<string> CreateAsync(UserCreateDto obj);
        Task UpdateAsync(UserDto obj, string[] roles);
        Task<IEnumerable<string>> GetRolesAsync();
        Task DeleteAsync(string id);
    }
}
