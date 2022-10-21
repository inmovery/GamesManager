using GamesManager.Contracts.Data.Entities;
using GamesManager.Contracts.Dto;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.Games.GetGamesOrderedByGenre
{
	public class GetGamesOrderedByGenreQuery : IRequest<IEnumerable<GameDto>>
	{
		public GetGamesOrderedByGenreQuery(GameGenre gameGenre)
		{
			GameGenre = gameGenre;
		}

		public GameGenre GameGenre { get; }
	}
}
