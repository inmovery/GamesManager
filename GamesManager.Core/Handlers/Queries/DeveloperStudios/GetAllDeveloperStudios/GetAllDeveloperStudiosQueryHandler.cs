using GamesManager.Contracts.Data;
using GamesManager.Contracts.Dto;
using AutoMapper;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.DeveloperStudios.GetAllDeveloperStudios
{
	public class GetAllDeveloperStudiosQueryHandler : IRequestHandler<GetAllDeveloperStudiosQuery, IEnumerable<DeveloperStudioDto>>
	{
		private readonly IUnitOfWork _repository;
		private readonly IMapper _mapper;

		public GetAllDeveloperStudiosQueryHandler(IUnitOfWork repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<DeveloperStudioDto>> Handle(GetAllDeveloperStudiosQuery request, CancellationToken cancellationToken)
		{
			var games = await Task.FromResult(_repository.DeveloperStudios.GetAsync());
			var result = _mapper.Map<IEnumerable<DeveloperStudioDto>>(games);

			return result;
		}
	}
}
