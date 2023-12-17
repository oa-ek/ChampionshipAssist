namespace ChampionshipAssist.Application.DTOs
{
	public class TournamentDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime? StartDate { get; set; } // Дата початку
		public DateTime? EndDate { get; set; } // Дата кінця
		public string? Game { get; set; } // Гра
		public string? ShortDesc { get; set; } // Короткий опис
		public string? LongDesc { get; set; } // Детальний опис
		public string? Rules { get; set; } // Правила
		public bool IsOpenToUsers { get; set; } = true; // Відкритий для звичайних користувачів?
		public bool IsOpenToCybersportsmen { get; set; } = true; // Відкритий для кіберспортсменів?
		public bool IsPrivate { get; set; } = false; // Якщо турнір приватний, то він не відображатиметься в публічному списку (але вони будуть відображатися для Адміністраторів). Однак його можна буде переглянути за допомогою посилання
		public bool VACBannedParticipantsAllowed { get; set; } = false; // Чи можуть користувачі з VAC-баном брати участь в турнірі
        public string OrganizerName { get; set; }
        public string? OrganizerId { get; set; }
    }
}
