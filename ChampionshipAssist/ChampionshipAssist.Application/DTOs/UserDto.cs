namespace ChampionshipAssist.Application.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SteamLink { get; set; }
        public string Documents { get; set; }
        public bool IsBanned { get; set; } = false;
        public bool IsVACBanned { get; set; } = false;
        public DateTime? BanDuration { get; set; } = DateTime.MinValue;
        public int? BanCount { get; set; } = 0;
        public string Bio { get; set; }
        public string Role { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
