using GamesManager.Contracts.Dto;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.DeveloperStudios.CreateDeveloperStudio
{
	public class CreateDeveloperStudioCommand : IRequest<DeveloperStudioDto>
	{
		public CreateDeveloperStudioCommand(CreateOrUpdateDeveloperStudioDto developerStudioModel)
		{
			DeveloperStudioModel = developerStudioModel;
		}

		public CreateOrUpdateDeveloperStudioDto DeveloperStudioModel { get; }
	}
}
