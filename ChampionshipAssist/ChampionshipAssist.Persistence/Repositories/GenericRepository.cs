using ChampionshipAssist.Core.Context;
using ChampionshipAssist.Core.Entities;
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

        public async Task<List<TEntity>> GetAllEntitiesAsync() =>
            await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetEntityByIdAsync(string id) =>
            await _context.Set<TEntity>().FindAsync(id);

        public async Task<List<TEntity>> GetEntitiesByPropertyAsync(string propertyName, string propertyValue)
        {
            var entities = await _context.Set<TEntity>()
                .Where(e => EF.Property<string>(e, propertyName) == propertyValue)
                .ToListAsync();

            return entities;
        }

        public async Task AddNewEntityAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExistingEntityAsync(TEntity updatedEntity)
        {
            _context.Update(updatedEntity);
            _context.Entry(updatedEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveExistingEntityAsync(TEntity removedEntity)
        {
            _context.Set<TEntity>().Remove(removedEntity);
            await _context.SaveChangesAsync();
        }
    }
}