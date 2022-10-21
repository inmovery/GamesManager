using GamesManager.Contracts.Enum;

namespace GamesManager.Contracts.Dto
{
	public class CreateOrUpdateGameDto
	{
		public Guid DeveloperStudioId { get; set; }

		public string Name { get; set; }

		public IEnumerable<GameGenre> GameGenres { get; set; }
	}
}
