using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChampionshipAssistBlazorRepresentation.Application
{
    public class TournamentModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? WinnerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Game { get; set; }
        public string? ShortDesc { get; set; }
        public string? LongDesc { get; set; }
        public string? Rules { get; set; }
        public bool IsOpenToUsers { get; set; }
        public bool IsOpenToCybersportsmen { get; set; }
        public bool IsPrivate { get; set; }
        public bool VACBannedParticipantsAllowed { get; set; }
        [NotMapped]
        public UserModel? Organizer { get; set; }
        public string OrganizerName { get; set; }
        public string? OrganizerId { get; set; }
        public ICollection<UserModel>? Participants { get; set; }
        public ICollection<ReviewModel>? Reviews { get; set; }
    }
}
