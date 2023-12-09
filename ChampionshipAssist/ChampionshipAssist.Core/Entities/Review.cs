using ChampionshipAssist.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampionshipAssist.Core.Entities
{
    public class Review : BaseEntity
    {
        public string? TournamentId { get; set; } // Ідентифікатор турніру
        public string? UserId { get; set; } // Ідентифікатор користувача
        public Tournament? Tournament { get; set; } 
        public User? User { get; set; } 
        public string? Commentary { get; set; } // Комментар
        public double? Rating { get; set; } // Рейтинг
    }
}
