using ChampionshipAssist.Core.Entities;

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
