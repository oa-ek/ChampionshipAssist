using ChampionshipAssist.Core.Context;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Repositories.Interfaces;

namespace ChampionshipAssist.Repositories.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private ChampionsshipAssistDbContext _context;

        public TournamentRepository(ChampionsshipAssistDbContext context)
        {
            _context = context;
        }
        public void Add(Tournament obj)
        {
            _context.Tournaments.Add(obj);
            Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Tournament Get(int id)
        {
            return _context.Tournaments.Find(id);
        }

        public IEnumerable<Tournament> GetAll()
        {
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
