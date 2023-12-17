namespace ChampionshipAssist.Application.DTOs
{
	public class ReviewDto
	{
		public string Id { get; set; }
		public string TournamentId { get; set; }
		public string UserId { get; set; }
		public string Commentary { get; set; }
		public double Rating { get; set; }
	}
}
