using ChampionshipAssist.Core.Entities;

namespace ChampionshipAssist.Domain.Contracts
{
	public interface IRepository<TEntity>

	where TEntity : class
	{
		public List<TEntity> GetAllEntities() =>
			GetAllEntitiesAsync().GetAwaiter().GetResult();

		public Task<List<TEntity>> GetAllEntitiesAsync();
		public Task<TEntity?> GetEntityByIdAsync(string id);
        public Task<List<TEntity>> GetEntitiesByPropertyAsync(string propertyName, string propertyValue); // Add this method
        public Task AddNewEntityAsync(TEntity entity);
        public Task UpdateExistingEntityAsync(TEntity updatedEntity);
        public Task RemoveExistingEntityAsync(TEntity removedEntity);
    }
}
