using ChampionshipAssist.Core.Entities;

namespace ChampionshipAssist.Repositories.Interfaces
{
    public interface ITournamentRepository : ISave
    {
        Tournament Get(string id);
        IEnumerable<Tournament> GetAll(string? username = null);
        void Add(Tournament obj, string username);
        void Update(Tournament obj);
        void Delete(string id);
    }
}
