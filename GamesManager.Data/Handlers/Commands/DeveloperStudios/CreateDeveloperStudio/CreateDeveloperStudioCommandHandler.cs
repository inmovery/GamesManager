using Microsoft.Extensions.Logging;
using GamesManager.Contracts.Data;
using GamesManager.Contracts.Dto;
using GamesManager.Contracts.Data.Entities;
using GamesManager.Core.Exceptions;
using FluentValidation;
using AutoMapper;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.DeveloperStudios.CreateDeveloperStudio
{
	public class CreateDeveloperStudioCommandHandler : IRequestHandler<CreateDeveloperStudioCommand, DeveloperStudioDto>
	{
		private readonly IUnitOfWork _repository;
		private readonly IValidator<CreateOrUpdateDeveloperStudioDto> _validator;
		private readonly IMapper _mapper;
		private readonly ILogger<CreateDeveloperStudioCommandHandler> _logger;

		public CreateDeveloperStudioCommandHandler(IUnitOfWork repository, IValidator<CreateOrUpdateDeveloperStudioDto> validator, IMapper mapper, ILogger<CreateDeveloperStudioCommandHandler> logger)
		{
			_repository = repository;
			_validator = validator;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<DeveloperStudioDto> Handle(CreateDeveloperStudioCommand request, CancellationToken cancellationToken)
		{
			var developerStudioModel = request.DeveloperStudioModel;
			var result = await _validator.ValidateAsync(developerStudioModel, cancellationToken);

			_logger.LogInformation($"CreateDeveloperStudio Validation result: {result}");

			if (!result.IsValid)
			{
				var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
				throw new InvalidRequestBodyException()
				{
					Errors = errors
				};
			}

			var developerStudio = _mapper.Map<DeveloperStudio>(developerStudioModel);

			await _repository.DeveloperStudios.AddAsync(developerStudio);
			await _repository.CommitAsync();

			return _mapper.Map<DeveloperStudioDto>(developerStudio);
		}
	}
}
