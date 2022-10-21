using GamesManager.Contracts.Data.Entities.Base;

namespace GamesManager.Contracts.Data.Entities
{
	/// <summary>
	/// <see cref="DeveloperStudio"/> describes a developer studio entities in a database
	/// </summary>
	public class DeveloperStudio : BaseEntity
	{
		public DeveloperStudio()
		{
		}

		public DeveloperStudio(Guid id)
			: base(id)
		{
		}

		/// <summary>
		/// Name of the developer studio
		/// </summary>
		public string? Name { get; set; }

		/// <summary>
		/// List of <see cref="Game"/> entities
		/// </summary>
		public virtual IEnumerable<Game>? Games { get; set; }

		public override bool Equals(object? obj)
		{
			return obj is DeveloperStudio developerStudio && Id.Equals(developerStudio.Id);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name, Games);
		}
	}
}
