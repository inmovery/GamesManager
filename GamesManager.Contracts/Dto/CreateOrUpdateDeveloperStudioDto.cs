using System.ComponentModel.DataAnnotations;

namespace GamesManager.Contracts.Dto
{
	public class CreateOrUpdateDeveloperStudioDto
	{
		[Required]
		public string Name { get; set; }
	}
}
