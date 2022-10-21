using GamesManager.Contracts.Dto;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.Games.CreateGame
{
	public class CreateGameCommand : IRequest<GameDto>
	{
		public CreateGameCommand(CreateOrUpdateGameDto model)
		{
			GameModel = model;
		}

		public CreateOrUpdateGameDto GameModel { get; }
	}
}
