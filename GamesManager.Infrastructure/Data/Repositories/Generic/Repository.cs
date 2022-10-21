using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using GamesManager.Migrations;
using GamesManager.Contracts.Data.Repositories.Base;

namespace GamesManager.Infrastructure.Data.Repositories.Generic
{
	public abstract class Repository<T> : IRepository<T>
		where T : class
	{
		private readonly DatabaseContext _databaseContext;
		protected readonly DbSet<T> DbSet;

		protected Repository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
			DbSet = _databaseContext.Set<T>();
		}

		public async Task<T> GetAsync(object id)
		{
			var item = await DbSet.FindAsync(id);
			return (await Task.FromResult(item))!;
		}

		public async Task AddAsync(T entity)
		{
			await DbSet.AddAsync(entity);
		}

		public async Task<T> DeleteAsync(object id)
		{
			var entity = await GetAsync(id);
			if ((entity as Task) == null)
				return await Task.FromResult(entity);

			if (_databaseContext.Entry(entity).State == EntityState.Detached)
				DbSet.Attach(entity);

			DbSet.Remove(entity);

			return await Task.FromResult(entity);
		}

		public Task<T> UpdateAsync(T entity)
		{
			DbSet.Attach(entity);
			_databaseContext.Entry(entity).State = EntityState.Modified;

			return Task.FromResult(entity);
		}

		public virtual IEnumerable<T> Find(Expression<Func<T, bool>> filterExpression)
		{
			return DbSet.Where(filterExpression);
		}

		public abstract Task<IEnumerable<T>> GetAsync();
	}
}
