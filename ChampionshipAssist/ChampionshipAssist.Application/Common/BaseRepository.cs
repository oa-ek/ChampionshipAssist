using ChampionshipAssist.Domain.Common;

namespace ChampionshipAssist.Application.Common
{
    public interface BaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
    }
}
