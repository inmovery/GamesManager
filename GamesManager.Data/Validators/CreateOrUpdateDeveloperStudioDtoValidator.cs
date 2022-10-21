using FluentValidation;
using GamesManager.Contracts.Dto;

namespace GamesManager.Core.Validators
{
	public class CreateOrUpdateDeveloperStudioDtoValidator : AbstractValidator<CreateOrUpdateDeveloperStudioDto>
	{
		public CreateOrUpdateDeveloperStudioDtoValidator()
		{
			RuleFor(gameModel => gameModel.Name).NotNull().NotEmpty().WithMessage("Name is required.");
		}
	}
}
