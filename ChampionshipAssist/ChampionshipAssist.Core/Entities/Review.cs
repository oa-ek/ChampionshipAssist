namespace ChampionshipAssist.Core.Entities
{
    public class Review
    {
        public int ReviewId { get; set; } // Ідентифікатор відгуку
        public int TournamentId { get; set; } // Ідентифікатор турніру
        public int UserId { get; set; } // Ідентифікатор користувача
        public string Commentary { get; set; } // Комментар
        public double Rating { get; set; } // Рейтинг
    }
}
