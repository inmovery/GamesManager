using Microsoft.Extensions.Logging;
using GamesManager.Contracts.Data;
using GamesManager.Contracts.Dto;
using GamesManager.Core.Exceptions;
using FluentValidation;
using AutoMapper;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.DeveloperStudios.UpdateDeveloperStudio
{
	public class UpdateDeveloperStudioCommandHandler : IRequestHandler<UpdateDeveloperStudioCommand, DeveloperStudioDto>
	{
		private readonly IUnitOfWork _repository;
		private readonly IValidator<CreateOrUpdateDeveloperStudioDto> _validator;
		private readonly IMapper _mapper;
		private readonly ILogger<UpdateDeveloperStudioCommandHandler> _logger;

		public UpdateDeveloperStudioCommandHandler(IUnitOfWork repository, IValidator<CreateOrUpdateDeveloperStudioDto> validator, IMapper mapper, ILogger<UpdateDeveloperStudioCommandHandler> logger)
		{
			_repository = repository;
			_validator = validator;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<DeveloperStudioDto> Handle(UpdateDeveloperStudioCommand request, CancellationToken cancellationToken)
		{
			var developerStudioModel = request.DeveloperStudioModel;
			var developerStudioId = request.DeveloperStudioId;

			var result = await _validator.ValidateAsync(developerStudioModel, cancellationToken);

			_logger.LogInformation($"UpdateDeveloperStudio Validation result: {result}");

			if (!result.IsValid)
			{
				var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
				throw new InvalidRequestBodyException
				{
					Errors = errors
				};
			}

			var developerStudio = await _repository.DeveloperStudios.GetAsync(developerStudioId);
			if (developerStudio == null)
				throw new EntityNotFoundException($"No DeveloperStudio found for the Id {developerStudioId}");

			developerStudio.Name = developerStudioModel.Name;

			await _repository.DeveloperStudios.UpdateAsync(developerStudio);
			await _repository.CommitAsync();

			var updatedGame = _mapper.Map<DeveloperStudioDto>(developerStudio);

			return updatedGame;
		}
	}
}
