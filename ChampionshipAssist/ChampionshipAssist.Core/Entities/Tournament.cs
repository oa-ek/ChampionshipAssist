using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipAssist.Core.Entities
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Rules { get; set; }
        public bool IsOpenToAll { get; set; }
        public List<User> Participants { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
