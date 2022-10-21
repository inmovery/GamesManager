using System.ComponentModel.DataAnnotations;

namespace GamesManager.Contracts.Data.Entities.Base
{
	public abstract class BaseEntity
	{
		protected BaseEntity()
		{
			Id = Guid.NewGuid();
		}

		protected BaseEntity(Guid id)
		{
			Id = id;
		}

		/// <summary>
		/// Unique Id key
		/// </summary>
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Date of creation of entity (observation inside specified table)
		/// </summary>
		[DataType(DataType.Date)]
		public virtual DateTime CreatedAt { get; set; }

		/// <summary>
		/// Date of modification of entity (observation inside specified table)
		/// </summary>
		[DataType(DataType.Date)]
		public virtual DateTime? LastModified { get; set; }
	}
}
