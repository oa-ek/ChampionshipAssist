namespace ChampionshipAssist.Core.Entities
{
    public class Organizer : User
    {
        public List<Tournament>? CreatedTournaments { get; set; }

        public void CreateTournament(string name, DateTime startDate, DateTime endDate, string organizerId, string rules, bool isOpenToUsers, bool isOpenToCybersportsmen, bool isPrivate, bool vBannedParticipantsAllowed)
        {
            var tournament = new Tournament
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                OrganizerId = organizerId,
                Rules = rules,
                IsOpenToUsers = isOpenToUsers,
                IsOpenToCybersportsmen = isOpenToCybersportsmen,
                IsPrivate = isPrivate,
                VACBannedParticipantsAllowed = vBannedParticipantsAllowed
            };

            CreatedTournaments.Add(tournament);
        }

        public void DeleteTournament(string id)
        {
            var tournamentToRemove = CreatedTournaments.FirstOrDefault(t => t.Id == id);
            if (tournamentToRemove != null)
            {
                CreatedTournaments.Remove(tournamentToRemove);
            }
        }

        public void EditTournament(string id, Tournament updatedTournament)
        {
            var existingTournament = CreatedTournaments.FirstOrDefault(t => t.Id == id);
            if (existingTournament != null)
            {
                // Оновити властивості турніру
                existingTournament.Name = updatedTournament.Name;
                existingTournament.StartDate = updatedTournament.StartDate;
                existingTournament.EndDate = updatedTournament.EndDate;
                existingTournament.Rules = updatedTournament.Rules;
                existingTournament.IsOpenToUsers = updatedTournament.IsOpenToUsers;
                existingTournament.IsOpenToCybersportsmen = updatedTournament.IsOpenToCybersportsmen;
                existingTournament.IsPrivate = updatedTournament.IsPrivate;
                existingTournament.VACBannedParticipantsAllowed = updatedTournament.VACBannedParticipantsAllowed;
            }
        }
    }
}
