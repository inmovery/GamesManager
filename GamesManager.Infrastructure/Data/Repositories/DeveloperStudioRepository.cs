using Microsoft.EntityFrameworkCore;
using GamesManager.Contracts.Data.Entities;
using GamesManager.Contracts.Data.Repositories;
using GamesManager.Infrastructure.Data.Repositories.Generic;
using GamesManager.Migrations;

namespace GamesManager.Infrastructure.Data.Repositories
{
	public class DeveloperStudioRepository : Repository<DeveloperStudio>, IDeveloperStudioRepository
	{
		public DeveloperStudioRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		public override Task<IEnumerable<DeveloperStudio>> GetAsync()
		{
			var developerStudios = DbSet
				.Include(dev => dev.Games)
				.OrderBy(dev => dev.Name).AsEnumerable();

			return Task.FromResult(developerStudios);
		}
	}
}
