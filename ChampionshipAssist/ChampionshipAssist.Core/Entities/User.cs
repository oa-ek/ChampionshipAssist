using Microsoft.AspNetCore.Identity;

namespace ChampionshipAssist.Core.Entities
{
    public class User : IdentityUser
    {
        public string? Name { get; set; } // Назва
        public string? SteamLink { get; set; } = "This user haven't set up this thing yet."; // Посилання на Steam
        public string? Documents { get; set; } = "This user haven't set up this thing yet."; // Посилання на документи, що підтверджують особу людини
        public string? Bio { get; set; } = "This user haven't set up this thing yet."; // Опис користувача
        public virtual ICollection<Tournament>? Tournaments { get; set; } // На яких турнірах користувач брав участь
        public bool? IsBanned { get; set; } = false; // По дефолту користувач не заблокований
        public bool? IsVACBanned { get; set; } = false; // По дефолту користувач не має VAC-Ban'у, але він буде виданий автоматично якщо профіль Steam матиме його
        public DateTime? BanDuration { get; set; } = DateTime.MinValue; // Дата, коли користувач знову зможе заходити на сайт
        public int? BanCount { get; set; } = 0; // По дефолту користувач не був заблокований.
    }
}
