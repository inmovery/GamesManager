using GamesManager.Contracts.Dto;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.DeveloperStudios.GetDeveloperStudioById
{
	public class GetDeveloperStudioByIdQuery : IRequest<DeveloperStudioDto>
	{
		public GetDeveloperStudioByIdQuery(Guid developerStudioId)
		{
			DeveloperStudioId = developerStudioId;
		}

		public Guid DeveloperStudioId { get; }
	}
}
