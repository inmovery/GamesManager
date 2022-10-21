using GamesManager.Contracts.Dto;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.Games.UpdateGame
{
	public class UpdateGameCommand : IRequest<GameDto>
	{
		public UpdateGameCommand(Guid gameId, CreateOrUpdateGameDto gameModel)
		{
			GameId = gameId;
			GameModel = gameModel;
		}

		public Guid GameId { get; set; }

		public CreateOrUpdateGameDto GameModel { get; }
	}
}
