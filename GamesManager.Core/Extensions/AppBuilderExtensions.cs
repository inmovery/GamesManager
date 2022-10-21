using Microsoft.AspNetCore.Builder;

namespace GamesManager.Core.Extensions
{
	public static class AppBuilderExtensions
	{
		/// <summary>
		/// Add usage dependencies of Swagger
		/// </summary>
		/// <param name="app">Application builder</param>
		/// <returns>Application builder</returns>
		public static IApplicationBuilder UseSwaggerWithAdvancedOptions(this IApplicationBuilder app)
		{
			app.UseSwagger(c =>
			{
				c.SerializeAsV2 = true;
			});

			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "Games API v1");
				options.RoutePrefix = string.Empty;
			});

			return app;
		}
	}
}
