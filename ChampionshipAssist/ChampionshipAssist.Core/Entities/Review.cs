namespace ChampionshipAssist.Core.Entities
{
    public class Review
    {
        public int ReviewId { get; set; } // Ідентифікатор відгуку
        public Tournament? Tournament { get; set; } // Ідентифікатор турніру
        public User? User { get; set; } // Ідентифікатор користувача
        public string? Commentary { get; set; } // Комментар
        public double? Rating { get; set; } // Рейтинг
    }
}
