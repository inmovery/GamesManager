using GamesManager.Contracts.Data.Entities;
using GamesManager.Contracts.Data.Repositories.Base;

namespace GamesManager.Contracts.Data.Repositories
{
	public interface IGameRepository : IRepository<Game>
	{
		Task<IEnumerable<Game>> GetGamesByGenreAsync(GameGenre genre);
	}
}
