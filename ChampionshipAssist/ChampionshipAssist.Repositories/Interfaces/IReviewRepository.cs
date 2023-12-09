using ChampionshipAssist.Core.Entities;

namespace ChampionshipAssist.Repositories.Interfaces
{
    public interface IReviewRepository : ISave
    {
        Review Get(int id);
        IEnumerable<Review> GetAll();
        void Add(Review obj);
        void Update(Review obj);
        void Delete(int id);
    }
}
