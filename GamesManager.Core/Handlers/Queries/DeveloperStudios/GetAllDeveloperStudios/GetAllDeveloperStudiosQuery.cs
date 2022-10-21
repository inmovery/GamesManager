using GamesManager.Contracts.Dto;
using MediatR;

namespace GamesManager.Core.Handlers.Queries.DeveloperStudios.GetAllDeveloperStudios
{
	public class GetAllDeveloperStudiosQuery : IRequest<IEnumerable<DeveloperStudioDto>>
	{
	}
}
