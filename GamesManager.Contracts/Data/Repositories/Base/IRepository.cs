using System.Linq.Expressions;

namespace GamesManager.Contracts.Data.Repositories.Base
{
	public interface IRepository<T> where T : class
	{
		/// <summary>
		/// Get all items
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<T>> GetAsync();

		/// <summary>
		/// Get specified item by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<T> GetAsync(object id);

		/// <summary>
		/// Add item to specified storage
		/// </summary>
		/// <param name="entity"></param>
		Task AddAsync(T entity);

		/// <summary>
		/// Delete specified item from storage
		/// </summary>
		/// <param name="id"></param>
		Task<T> DeleteAsync(object id);

		/// <summary>
		/// Update specified item inside storage
		/// </summary>
		/// <param name="entity"></param>
		Task<T> UpdateAsync(T entity);

		/// <summary>
		/// Perform query to receive specified items
		/// </summary>
		/// <param name="filterExpression"></param>
		/// <returns></returns>
		IEnumerable<T> Find(Expression<Func<T, bool>> filterExpression);
	}
}
