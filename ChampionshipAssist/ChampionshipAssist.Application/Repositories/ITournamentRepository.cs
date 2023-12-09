using ChampionshipAssist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipAssist.Repositories.Interfaces
{
    public interface ITournamentRepository : ISave
    {
        Tournament Get(int id);
        IEnumerable<Tournament> GetAll();
        void Add(Tournament obj);
        void Update(Tournament obj);
        void Delete(int id);
    }
}
