using GamesManager.Migrations;
using Microsoft.EntityFrameworkCore;

namespace GamesManager.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = CreateHostBuilder(args).Build();

			using var scope = builder.Services.CreateScope();
			var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

			var areThereAnyPendingMigrations = databaseContext.Database.GetPendingMigrations().Any();
			if (areThereAnyPendingMigrations)
				databaseContext.Database.Migrate();

			builder.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
