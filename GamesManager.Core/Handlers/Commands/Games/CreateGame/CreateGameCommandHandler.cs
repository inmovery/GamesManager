using Microsoft.Extensions.Logging;
using GamesManager.Core.Exceptions;
using GamesManager.Contracts.Data;
using GamesManager.Contracts.Data.Entities;
using GamesManager.Contracts.Dto;
using FluentValidation;
using AutoMapper;
using GamesManager.Contracts.Enum;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.Games.CreateGame
{
	public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameDto>
	{
		private readonly IUnitOfWork _repository;
		private readonly IValidator<CreateOrUpdateGameDto> _validator;
		private readonly IMapper _mapper;
		private readonly ILogger<CreateGameCommandHandler> _logger;

		public CreateGameCommandHandler(IUnitOfWork repository, IValidator<CreateOrUpdateGameDto> validator, IMapper mapper, ILogger<CreateGameCommandHandler> logger)
		{
			_repository = repository;
			_validator = validator;
			_logger = logger;
			_mapper = mapper;
		}

		public async Task<GameDto> Handle(CreateGameCommand request, CancellationToken cancellationToken)
		{
			var gameModel = request.GameModel;
			var result = await _validator.ValidateAsync(gameModel, cancellationToken);

			_logger.LogInformation($"CreateGame Validation result: {result}");

			if (!result.IsValid)
			{
				var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
				throw new InvalidRequestBodyException()
				{
					Errors = errors
				};
			}

			var game = _mapper.Map<Game>(gameModel);

			//var game = new Game
			//{
			//	Name = gameModel.Name,
			//	GameGenres = gameModel.GameGenres.ToHashSet(),
			//	DeveloperStudioId = gameModel.DeveloperStudioId,
			//};

			await _repository.Games.AddAsync(game);
			await _repository.CommitAsync();

			return _mapper.Map<GameDto>(game);
		}
	}
}
