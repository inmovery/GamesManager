using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace GamesManager.Migrations.Options
{
	public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
	{
		private const string ConfigurationSectionName = "DatabaseOptions";
		private readonly IConfiguration _configuration;

		public DatabaseOptionsSetup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		/// <summary>
		/// Configure database options
		/// </summary>
		/// <param name="options"></param>
		public void Configure(DatabaseOptions options)
		{
			var connectionString = _configuration.GetConnectionString("Database");

			options.ConnectionString = connectionString;

			_configuration.GetSection(ConfigurationSectionName).Bind(options);
		}
	}
}
