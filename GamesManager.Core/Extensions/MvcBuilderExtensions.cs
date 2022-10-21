using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace GamesManager.Core.Extensions
{
	public static class MvcBuilderExtensions
	{
		/// <summary>
		/// Add advanced json options
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static IMvcBuilder AddAdvancedJsonOptions(this IMvcBuilder builder)
		{
			builder.AddNewtonsoftJson(options =>
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

			return builder;
		}
	}
}
