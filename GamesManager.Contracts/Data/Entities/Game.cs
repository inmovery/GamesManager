using GamesManager.Contracts.Data.Entities.Base;

namespace GamesManager.Contracts.Data.Entities
{
	/// <summary>
	/// <see cref="Game"/> describes a game entities in a database
	/// </summary>
	public class Game : BaseEntity
	{
		public Game()
		{
		}

		public Game(Guid id)
			: base(id)
		{
		}

		/// <summary>
		/// Name of the game
		/// </summary>
		public string? Name { get; set; }

		/// <summary>
		/// List of <see cref="GameGenre"/> enumerations
		/// </summary>
		public List<GameGenre> GameGenres { get; set; }

		/// <summary>
		/// Navigation property for table of developer studios
		/// </summary>
		public Guid? DeveloperStudioId { get; set; }

		/// <summary>
		/// Navigation property for table of developer studios
		/// </summary>
		public virtual DeveloperStudio? DeveloperStudio { get; set; }

		public override bool Equals(object? obj)
		{
			return obj is Game game && Id.Equals(game.Id);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name, GameGenres, DeveloperStudioId, DeveloperStudio);
		}
	}
}
