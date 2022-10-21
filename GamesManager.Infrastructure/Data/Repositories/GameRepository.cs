using Microsoft.EntityFrameworkCore;
using GamesManager.Contracts.Data.Entities;
using GamesManager.Contracts.Data.Repositories;
using GamesManager.Infrastructure.Data.Repositories.Generic;
using GamesManager.Migrations;

namespace GamesManager.Infrastructure.Data.Repositories
{
	public class GameRepository : Repository<Game>, IGameRepository
	{
		public GameRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		public override Task<IEnumerable<Game>> GetAsync()
		{
			var games = DbSet
				.Include(game => game.DeveloperStudio)
				.OrderBy(game => game.Name).AsEnumerable();

			return Task.FromResult(games);
		}

		public Task<IEnumerable<Game>> GetGamesByGenreAsync(GameGenre genre)
		{
			var gameList = DbSet
				.Include(game => game.DeveloperStudio)
				.Where(game => game.GameGenres!.Contains(genre))
				.OrderBy(game => game.Name).AsEnumerable();

			return Task.FromResult(gameList);
		}
	}
}
