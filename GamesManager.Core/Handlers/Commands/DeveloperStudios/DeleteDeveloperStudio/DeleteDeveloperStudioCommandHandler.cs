using GamesManager.Contracts.Data;
using MediatR;

namespace GamesManager.Core.Handlers.Commands.DeveloperStudios.DeleteDeveloperStudio
{
	public class DeleteDeveloperStudioCommandHandler : IRequestHandler<DeleteDeveloperStudioCommand, Guid>
	{
		private readonly IUnitOfWork _repository;

		public DeleteDeveloperStudioCommandHandler(IUnitOfWork repository)
		{
			_repository = repository;
		}

		public async Task<Guid> Handle(DeleteDeveloperStudioCommand request, CancellationToken cancellationToken)
		{
			var developerStudioId = request.DeveloperStudioId;

			await _repository.DeveloperStudios.DeleteAsync(developerStudioId);
			await _repository.CommitAsync();

			return developerStudioId;
		}
	}
}
