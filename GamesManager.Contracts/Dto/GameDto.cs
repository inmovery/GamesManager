using System.ComponentModel.DataAnnotations;
using GamesManager.Contracts.Enum;

namespace GamesManager.Contracts.Dto
{
	public class GameDto
	{
		[Required]
		public Guid DeveloperStudioId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public IEnumerable<GameGenre> GameGenres { get; set; }
	}
}
