namespace ChampionshipAssistBlazorRepresentation.Application
{
    public class UserModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? SteamLink { get; set; } = "This user hasn't set up this thing yet.";
        public string? Documents { get; set; } = "This user hasn't set up this thing yet.";
        public string? Bio { get; set; } = "This user hasn't set up this thing yet.";
        public ICollection<TournamentModel>? Tournaments { get; set; }
        public bool IsBanned { get; set; } = false;
        public bool IsVACBanned { get; set; } = false;
        public DateTime? BanDuration { get; set; } = DateTime.MinValue;
        public int? BanCount { get; set; } = 0;
        public string Role { get; set; }
    }
}
