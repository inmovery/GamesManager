using GamesManager.Contracts.Data.Entities;
using GamesManager.Contracts.Data.Entities.Base;
using GamesManager.Contracts.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GamesManager.Migrations
{
	public sealed class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public DbSet<Game> Games { get; set; }

		public DbSet<DeveloperStudio> DeveloperStudios { get; set; }

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var item in ChangeTracker.Entries<Game>().AsEnumerable())
			{
				if (item.State == EntityState.Added)
					item.Entity.CreatedAt = DateTime.UtcNow;
			}

			foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
			{
				switch (item.State)
				{
					case EntityState.Added:
						item.Entity.CreatedAt = DateTime.UtcNow;
						break;
					case EntityState.Modified:
						item.Entity.LastModified = DateTime.UtcNow;
						break;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DeveloperStudio>(developerStudio =>
			{
				developerStudio.HasKey(item => item.Id);
			});

			modelBuilder.Entity<DeveloperStudio>()
				.Property(developerStudio => developerStudio.Id)
				.ValueGeneratedOnAdd();

			//var enumConverter = new ValueConverter<List<GameGenre>, List<int>>(
			//	to => to.ConvertAll(value => (int)value),
			//	from => from.ConvertAll(value => (GameGenre)value));

			//modelBuilder.Entity<Game>()
			//	.Property(game => game.GameGenres)
			//	.HasConversion(enumConverter!);

			modelBuilder.Entity<DeveloperStudio>()
				.HasMany(developerStudio => developerStudio.Games)
				.WithOne(game => game.DeveloperStudio)
				.HasForeignKey(game => game.DeveloperStudioId);

			// ToDo: fix unique constraint violation exception
			//modelBuilder.Entity<Game>()
			//	.HasIndex(game => game.DeveloperStudio)
			//	.IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}
