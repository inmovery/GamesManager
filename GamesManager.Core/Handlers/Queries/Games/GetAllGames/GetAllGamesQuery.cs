using GamesManager.Contracts.Dto;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.Games.GetAllGames
{
	public class GetAllGamesQuery : IRequest<IEnumerable<GameDto>>
	{
	}
}
