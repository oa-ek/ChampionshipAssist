using ChampionshipAssist.Core.Context;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Repositories.Interfaces;

namespace ChampionshipAssist.Repositories.Repos
{
    public class ReviewRepository : IReviewRepository
    {
        private ChampionsshipAssistDbContext _context;

        public ReviewRepository(ChampionsshipAssistDbContext context)
        {
            _context = context;
        }
        public void Add(Review obj)
        {
            _context.Reviews.Add(obj);
            Save();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Review Get(string id)
        {
            return _context.Reviews.Find(id);
        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Review obj)
        {
            _context.Reviews.Update(obj);
        }
    }
}
