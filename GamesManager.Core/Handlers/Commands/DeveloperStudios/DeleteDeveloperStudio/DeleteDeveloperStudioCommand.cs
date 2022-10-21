using MediatR;

namespace GamesManager.Core.Handlers.Commands.DeveloperStudios.DeleteDeveloperStudio
{
	public class DeleteDeveloperStudioCommand : IRequest<Guid>
	{
		public DeleteDeveloperStudioCommand(Guid developerStudioId)
		{
			DeveloperStudioId = developerStudioId;
		}

		public Guid DeveloperStudioId { get; }
	}
}
