using ChampionshipAssist.Core.Context;
using ChampionshipAssist.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        private readonly ChampionshipAssistDbContext _context;

        public GenericRepository(ChampionshipAssistDbContext dbContext) =>
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public Task<List<TEntity>> GetAllEntitiesAsync() =>
             _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetEntityByIdAsync(string id) =>
            await _context.Set<TEntity>().FindAsync(id);

        public async Task AddNewEntityAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void UpdateExistingEntity(TEntity updatedEntity)
        {
            _context.Set<TEntity>().Update(updatedEntity);
            _context.SaveChanges();
        }

        public void RemoveExistingEntity(TEntity removedEntity)
        {
            _context.Set<TEntity>().Remove(removedEntity);
            _context.SaveChanges();
        }
    }
}
