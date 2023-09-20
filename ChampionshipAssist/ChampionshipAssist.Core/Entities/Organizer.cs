namespace ChampionshipAssist.Core.Entities
{
    public class Organizer : User
    {
        public List<Tournament> CreatedTournaments { get; set; }

        public void CreateTournament(string name, DateTime startDate, DateTime endDate, string rules, bool isOpenToAll)
        {
            var tournament = new Tournament
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Rules = rules,
                IsOpenToAll = isOpenToAll
            };

            CreatedTournaments.Add(tournament);
        }

        public void DeleteTournament(int tournamentId)
        {
            var tournamentToRemove = CreatedTournaments.FirstOrDefault(t => t.TournamentId == tournamentId);
            if (tournamentToRemove != null)
            {
                CreatedTournaments.Remove(tournamentToRemove);
            }
        }

        public void EditTournament(int tournamentId, Tournament updatedTournament)
        {
            var existingTournament = CreatedTournaments.FirstOrDefault(t => t.TournamentId == tournamentId);
            if (existingTournament != null)
            {
                // Оновити властивості турніру
                existingTournament.Name = updatedTournament.Name;
                existingTournament.StartDate = updatedTournament.StartDate;
                existingTournament.EndDate = updatedTournament.EndDate;
                existingTournament.Rules = updatedTournament.Rules;
                existingTournament.IsOpenToAll = updatedTournament.IsOpenToAll;
            }
        }
    }
}
