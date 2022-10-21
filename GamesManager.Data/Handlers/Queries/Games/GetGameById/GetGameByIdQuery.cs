using GamesManager.Contracts.Dto;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.Games.GetGameById
{
	public class GetGameByIdQuery : IRequest<GameDto>
	{
		public GetGameByIdQuery(Guid gameId)
		{
			GameId = gameId;
		}

		public Guid GameId { get; }
	}
}
