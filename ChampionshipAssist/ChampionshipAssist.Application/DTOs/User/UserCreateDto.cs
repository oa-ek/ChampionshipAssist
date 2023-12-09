using System.ComponentModel.DataAnnotations;

namespace ChampionshipAssist.Repositories.DTOs.User
{
    public class UserCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SteamLink { get; set; }
        public string Documents { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
