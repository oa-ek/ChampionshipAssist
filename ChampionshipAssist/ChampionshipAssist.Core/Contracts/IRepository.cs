﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipAssist.Domain.Contracts
{
	public interface IRepository<TEntity>

	where TEntity : class
	{
		public List<TEntity> GetAllEntities() =>
			GetAllEntitiesAsync().GetAwaiter().GetResult();

		public Task<List<TEntity>> GetAllEntitiesAsync();
		public Task<TEntity?> GetEntityByIdAsync(string id);
		public Task AddNewEntityAsync(TEntity entity);
		public void UpdateExistingEntity(TEntity updatedEntity);
		public void RemoveExistingEntity(TEntity removedEntity);
	}
}
