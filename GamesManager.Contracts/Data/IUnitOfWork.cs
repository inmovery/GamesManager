using GamesManager.Contracts.Data.Repositories;

namespace GamesManager.Contracts.Data
{
	public interface IUnitOfWork : IDisposable
	{
		IGameRepository Games { get; }

		IDeveloperStudioRepository DeveloperStudios { get; }

		Task CommitAsync();
	}
}
