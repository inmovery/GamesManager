using Microsoft.Extensions.Logging;
using GamesManager.Contracts.Data;
using GamesManager.Contracts.Dto;
using GamesManager.Core.Exceptions;
using AutoMapper;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.Games.GetGameById
{
	public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameDto>
	{
		private readonly IUnitOfWork _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetGameByIdQueryHandler> _logger;

		public GetGameByIdQueryHandler(IUnitOfWork repository, IMapper mapper, ILogger<GetGameByIdQueryHandler> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<GameDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
		{
			var gameId = request.GameId;
			var game = await Task.FromResult(_repository.Games.GetAsync(gameId));
			if (game == null)
				throw new EntityNotFoundException($"No game found for Id {gameId}");

			var result = _mapper.Map<GameDto>(game);

			return result;
		}
	}
}
