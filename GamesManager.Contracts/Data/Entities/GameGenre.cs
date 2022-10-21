using GamesManager.Contracts.Data.Entities.Base;

namespace GamesManager.Contracts.Data.Entities
{
	/// <summary>
	/// <see cref="Game"/> describes a game genre entities in a database
	/// </summary>
	public class GameGenre : BaseEntity
	{
		public GameGenre()
		{
		}

		public GameGenre(Guid id)
			: base(id)
		{
		}

		/// <summary>
		/// Name of the game genre
		/// </summary>
		public string? Name { get; set; }
	}
}
