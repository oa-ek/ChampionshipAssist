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
        public bool? IsOpenToAll { get; set; } // Відкритий для всіх? Якщо ні, то там можуть бути лише кіберспортсмени
        public bool? IsPrivate { get; set; } // Якщо турнір приватний, то він не відображатиметься в публічному списку (але вони будуть відображатися для Адміністраторів). Однак його можна буде переглянути за допомогою посилання
        public bool? VACBannedParticipantsAllowed { get; set; } // Чи можуть користувачі з VAC-баном брати участь в турнірі
        public List<User>? Participants { get; set; } // Учасники
        public List<Review>? Reviews { get; set; } // Відгуки
    }
}
