using GamesManager.Contracts.Data;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.Games.DeleteGame
{
	public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Guid>
	{
		private readonly IUnitOfWork _repository;

		public DeleteGameCommandHandler(IUnitOfWork repository)
		{
			_repository = repository;
		}

		public async Task<Guid> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
		{
			var gameId = request.GameId;

			await _repository.Games.DeleteAsync(gameId);
			await _repository.CommitAsync();

			return gameId;
		}
	}
}
