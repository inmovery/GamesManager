using Microsoft.Extensions.Logging;
using GamesManager.Contracts.Data;
using GamesManager.Contracts.Dto;
using GamesManager.Core.Exceptions;
using FluentValidation;
using AutoMapper;
using GamesManager.Contracts.Data.Entities;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.Games.UpdateGame
{
	public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, GameDto>
	{
		private readonly IUnitOfWork _repository;
		private readonly IValidator<CreateOrUpdateGameDto> _validator;
		private readonly IMapper _mapper;
		private readonly ILogger<UpdateGameCommandHandler> _logger;

		public UpdateGameCommandHandler(IUnitOfWork repository, IValidator<CreateOrUpdateGameDto> validator, IMapper mapper, ILogger<UpdateGameCommandHandler> logger)
		{
			_repository = repository;
			_validator = validator;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<GameDto> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
		{
			var gameModel = request.GameModel;
			var gameId = request.GameId;

			var result = await _validator.ValidateAsync(gameModel, cancellationToken);

			_logger.LogInformation($"UpdateGame Validation result: {result}");

			if (!result.IsValid)
			{
				var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
				throw new InvalidRequestBodyException
				{
					Errors = errors
				};
			}

			var game = await _repository.Games.GetAsync(gameId);
			if (game == null)
				throw new EntityNotFoundException($"No Game found for the Id {gameId}");


			var newGame = _mapper.Map<Game>(gameModel);
			_mapper.Map(newGame, game);

			//game.Name = gameModel.Name;
			//game.GameGenres = gameModel.GameGenres.ToArray();
			//game.DeveloperStudioId = gameModel.DeveloperStudioId;

			await _repository.Games.UpdateAsync(game);
			await _repository.CommitAsync();

			var updatedGame = _mapper.Map<GameDto>(game);

			return updatedGame;
		}
	}
}
