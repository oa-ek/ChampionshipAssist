using ChampionshipAssist.Core.Entities;

namespace ChampionshipAssist.Repositories.Interfaces
{
    public interface IReviewRepository : ISave
    {
        Review Get(string id);
        IEnumerable<Review> GetAll();
        void Add(Review obj);
        void Update(Review obj);
        void Delete(string id);
    }
}
