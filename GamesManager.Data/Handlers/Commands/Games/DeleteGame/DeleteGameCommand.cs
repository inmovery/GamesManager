using MediatR;

namespace GamesManager.Core.Handlers.Commands.Games.DeleteGame
{
	public class DeleteGameCommand : IRequest<Guid>
	{
		public DeleteGameCommand(Guid gameId)
		{
			GameId = gameId;
		}

		public Guid GameId { get; }
	}
}
