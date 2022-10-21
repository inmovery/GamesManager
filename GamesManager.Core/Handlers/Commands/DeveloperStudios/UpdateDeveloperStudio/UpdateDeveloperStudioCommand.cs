using GamesManager.Contracts.Dto;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.DeveloperStudios.UpdateDeveloperStudio
{
	public class UpdateDeveloperStudioCommand : IRequest<DeveloperStudioDto>
	{
		public UpdateDeveloperStudioCommand(Guid developerStudioId, CreateOrUpdateDeveloperStudioDto developerStudioModel)
		{
			DeveloperStudioId = developerStudioId;
			DeveloperStudioModel = developerStudioModel;
		}

		public Guid DeveloperStudioId { get; set; }

		public CreateOrUpdateDeveloperStudioDto DeveloperStudioModel { get; }
	}
}
