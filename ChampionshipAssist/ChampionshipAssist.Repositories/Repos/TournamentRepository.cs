using ChampionshipAssist.Core.Context;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.Repositories.Repos
{
    public class TournamentRepository : ITournamentRepository
    {
        private ChampionshipAssistDbContext _context;

        public TournamentRepository(ChampionshipAssistDbContext context)
        {
            _context = context;
        }
        public void Add(Tournament obj, string username)
        {
            obj.Organizer = _context.Users.First(x => x.UserName == username);
            _context.Tournaments.Add(obj);
            Save();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Tournament Get(string id)
        {
            return _context.Tournaments
                .Include(x => x.Reviews)
                .Include(x => x.Participants).First(x => x.Id == id);
        }

        public IEnumerable<Tournament> GetAll(string? username)
        {
            if (username is null)
                return _context.Tournaments.ToList();

            return _context.Tournaments.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Tournament obj)
        {
            _context.Tournaments.Update(obj);
        }
    }
}
