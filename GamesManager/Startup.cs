using GamesManager.Core.Extensions;
using GamesManager.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GamesManager.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.ConfigureCors();

			services.AddPersistence(Configuration);
			services.AddCore(Configuration);

			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});

			services.AddSwaggerWithComments();

			services.AddControllers().AddAdvancedJsonOptions();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwaggerWithAdvancedOptions();

			app.UseCors(builder =>
			{
				builder.AllowAnyHeader()
					.AllowAnyOrigin()
					.AllowAnyMethod();
			});

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
