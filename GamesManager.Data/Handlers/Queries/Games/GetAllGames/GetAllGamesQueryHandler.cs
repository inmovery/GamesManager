using GamesManager.Contracts.Data;
using GamesManager.Contracts.Dto;
using AutoMapper;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.Games.GetAllGames
{
	public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, IEnumerable<GameDto>>
	{
		private readonly IUnitOfWork _repository;
		private readonly IMapper _mapper;

		public GetAllGamesQueryHandler(IUnitOfWork repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<GameDto>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
		{
			var developerStudios = await Task.FromResult(_repository.Games.GetAsync());
			var result = _mapper.Map<IEnumerable<GameDto>>(developerStudios);

			return result;
		}
	}
}
