using System.Reflection.Metadata;

namespace ChampionshipAssist.Core.Entities
{
    public class User
    {
        public int UserId { get; set; } // Ідентифікатор користувача
        public string Username { get; set; } // Назва
        public string Password { get; set; } // Пароль
        public string SteamLink { get; set; } // Посилання на стім
        public string Documents { get; set; } // Посилання на документи, що підтверджують особу людини
        public bool IsAdmin { get; set; } = false; // По дефолту користувач не є адміном
    }
}
