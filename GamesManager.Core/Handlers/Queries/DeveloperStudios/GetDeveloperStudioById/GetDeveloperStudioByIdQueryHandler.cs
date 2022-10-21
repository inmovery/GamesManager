using Microsoft.Extensions.Logging;
using GamesManager.Contracts.Data;
using GamesManager.Contracts.Dto;
using GamesManager.Core.Exceptions;
using AutoMapper;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.DeveloperStudios.GetDeveloperStudioById
{
	public class GetDeveloperStudioByIdQueryHandler : IRequestHandler<GetDeveloperStudioByIdQuery, DeveloperStudioDto>
	{
		private readonly IUnitOfWork _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetDeveloperStudioByIdQueryHandler> _logger;

		public GetDeveloperStudioByIdQueryHandler(IUnitOfWork repository, IMapper mapper, ILogger<GetDeveloperStudioByIdQueryHandler> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<DeveloperStudioDto> Handle(GetDeveloperStudioByIdQuery request, CancellationToken cancellationToken)
		{
			var developerStudioId = request.DeveloperStudioId;

			var developerStudio = await Task.FromResult(_repository.Games.GetAsync(developerStudioId));
			if (developerStudio == null)
				throw new EntityNotFoundException($"No developer studio found for Id {developerStudioId}");

			var result = _mapper.Map<DeveloperStudioDto>(developerStudio);

			return result;
		}
	}
}
