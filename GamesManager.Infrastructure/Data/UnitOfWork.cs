using GamesManager.Contracts.Data;
using GamesManager.Contracts.Data.Repositories;
using GamesManager.Infrastructure.Data.Repositories;
using GamesManager.Migrations;

namespace GamesManager.Infrastructure.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DatabaseContext _databaseContext;

		public UnitOfWork(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public IGameRepository Games => new GameRepository(_databaseContext);

		public IDeveloperStudioRepository DeveloperStudios => new DeveloperStudioRepository(_databaseContext);

		public async Task CommitAsync()
		{
			await _databaseContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_databaseContext.Dispose();
		}
	}
}
