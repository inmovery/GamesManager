namespace GamesManager.Migrations.Options
{
	public class DatabaseOptions
	{
		/// <summary>
		/// String that performs connection to database
		/// </summary>
		public string ConnectionString { get; set; } = string.Empty;

		/// <summary>
		/// Max count to retry connections
		/// </summary>
		public int MaxRetryCount { get; set; }

		/// <summary>
		/// Max timeout before each attempt to connection to database
		/// </summary>
		public int CommandTimeout { get; set; }

		/// <summary>
		/// Flag that performs enable detailed errors flag
		/// </summary>
		public bool EnableDetailedErrors { get; set; }

		/// <summary>
		/// Flag that performs enable sensitive data logging
		/// </summary>
		public bool EnableSensitiveDataLogging { get; set; }
	}
}
