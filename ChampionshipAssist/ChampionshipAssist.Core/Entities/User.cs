using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;

namespace ChampionshipAssist.Core.Entities
{
    public class User : IdentityUser
    {
        public int Id { get; set; } // Ідентифікатор користувача
        public string? Username { get; set; } // Назва
        public string? Password { get; set; } // Пароль
        public string? SteamLink { get; set; } // Посилання на стім
        public string? Documents { get; set; } // Посилання на документи, що підтверджують особу людини
        public List<Tournament>? Tournaments { get; set; } // На яких турнірах користувач брав участь
        public bool IsAdmin { get; set; } = false; // По дефолту користувач не є адміном
        public bool IsBanned { get; set; } = false; // По дефолту користувач не заблокований
        public bool IsVACBanned { get; set; } = false; // По дефолту користувач не має VAC-Ban'у, але він буде виданий автоматично якщо профіль Steam матиме його
        public DateTime BanDuration { get; set; } // Дата, коли користувач знову зможе заходити на сайт
        public string AccountStatus { get; set; } = "User"; // User - звичайний користувач, Cybersportsman - киберспортсмен, Administrator - адміністратор сайту
        public int BanCount { get; set; } = 0; // По дефолту користувач не був заблокований.
    }
}
