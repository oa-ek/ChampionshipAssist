using System;
using System.Collections.Generic;
namespace ChampionshipAssist.Core.Entities
{
    public class Tournament
    {
        public int TournamentId { get; set; } // Ідентифікатор турніру
        public string? Name { get; set; } // Назва
        public DateTime? StartDate { get; set; } // Дата початку
        public DateTime? EndDate { get; set; } // Дата кінця
        public string? Rules { get; set; } // Правила
        public bool? IsOpenToAll { get; set; } // Відкритий для всіх?
        public List<User>? Participants { get; set; } // Учасники
        public List<Review>? Reviews { get; set; } // Відгуки
    }
}
