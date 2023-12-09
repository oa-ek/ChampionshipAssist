using ChampionshipAssist.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipAssist.Repositories.Interfaces
{
    public interface IUserRepository : ISave
    {
        User Get(int id);
        IEnumerable<User> GetAll();
        void Add(User obj);
        void Update(User obj);
        void Delete(int id);
    }
}
