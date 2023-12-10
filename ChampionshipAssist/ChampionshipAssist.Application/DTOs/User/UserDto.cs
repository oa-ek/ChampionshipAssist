namespace ChampionshipAssist.Repositories.DTOs.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SteamLink { get; set; }
        public string Bio { get; set; }
        public List<string> Roles { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
