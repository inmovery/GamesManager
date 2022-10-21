using GamesManager.Contracts.Data;
using GamesManager.Contracts.Dto;
using AutoMapper;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.Games.GetGamesOrderedByGenre
{
	public class GetGamesOrderedByGenreQueryHandler : IRequestHandler<GetGamesOrderedByGenreQuery, IEnumerable<GameDto>>
	{
		private readonly IUnitOfWork _repository;
		private readonly IMapper _mapper;

		public GetGamesOrderedByGenreQueryHandler(IUnitOfWork repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<GameDto>> Handle(GetGamesOrderedByGenreQuery request, CancellationToken cancellationToken)
		{
			var gameGenre = request.GameGenre;
			var games = await Task.FromResult(_repository.Games.GetGamesByGenreAsync(gameGenre));

			var result = _mapper.Map<IEnumerable<GameDto>>(games);

			return result;
		}
	}
}
