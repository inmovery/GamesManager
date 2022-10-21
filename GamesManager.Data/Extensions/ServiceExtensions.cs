using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;

namespace GamesManager.Core.Extensions
{
	public static class ServiceExtensions
	{
		/// <summary>
		/// Add service collection related to core layer of architecture
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
		{
			return services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
				.AddAutoMapper(Assembly.GetExecutingAssembly())
				.AddMediatR(Assembly.GetExecutingAssembly());
		}

		/// <summary>
		/// Add service collection related to swagger implementation
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwaggerWithComments(this IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			return services.AddSwaggerGen(options =>
			{
				var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
				options.IncludeXmlComments(xmlCommentsPath);
			});
		}
	}
}
