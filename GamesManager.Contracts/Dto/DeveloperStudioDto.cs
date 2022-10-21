using System.ComponentModel.DataAnnotations;

namespace GamesManager.Contracts.Dto
{
	public class DeveloperStudioDto
	{
		[Required]
		public string Name { get; set; }
	}
}
