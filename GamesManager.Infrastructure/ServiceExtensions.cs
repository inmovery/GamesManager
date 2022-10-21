using GamesManager.Contracts.Data;
using GamesManager.Infrastructure.Data;
using GamesManager.Migrations.Options;
using GamesManager.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GamesManager.Infrastructure
{
	public static class ServiceExtensions
	{
		/// <summary>
		/// Add dependencies of UnitOfWork pattern
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
		{
			return services.AddScoped<IUnitOfWork, UnitOfWork>();
		}

		/// <summary>
		/// Add database dependencies
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.ConfigureOptions<DatabaseOptionsSetup>();

			var connectionString = configuration.GetConnectionString("Database");

			return services.AddDbContext<DatabaseContext>((serviceProvider, dbContextOptionsBuilder) =>
			{
				var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

				dbContextOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
				{
					var databaseAssemblyName = typeof(DatabaseContext).Namespace;
					sqlServerAction.MigrationsAssembly(databaseAssemblyName);

					sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

					sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
				});

				dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);

				dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
			});
		}

		/// <summary>
		/// Add dependencies related to persistence layer of architecture
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			return services.AddDatabaseContext(configuration).AddUnitOfWork();
		}

		/// <summary>
		/// Configure CORS options
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});
		}
	}
}
