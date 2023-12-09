using System.ComponentModel.DataAnnotations.Schema;

namespace ChampionshipAssist.Core.Entities
{
    public class Review
    {
        public int Id { get; set; } // Ідентифікатор відгуку
        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public Tournament? Tournament { get; set; } // Ідентифікатор турніру
        public User? User { get; set; } // Ідентифікатор користувача
        public string? Commentary { get; set; } // Комментар
        public double? Rating { get; set; } // Рейтинг
    }
}
