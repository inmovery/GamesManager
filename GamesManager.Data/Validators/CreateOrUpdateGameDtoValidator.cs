using FluentValidation;
using GamesManager.Contracts.Dto;

namespace GamesManager.Core.Validators
{
	public class CreateOrUpdateGameDtoValidator : AbstractValidator<CreateOrUpdateGameDto>
	{
		public CreateOrUpdateGameDtoValidator()
		{
			RuleFor(gameModel => gameModel.Name).NotNull().NotEmpty().WithMessage("Name is required.");
			RuleFor(gameModel => gameModel.GameGenres).NotNull().NotEmpty().WithMessage("Game mush have at least 1 genre.");
		}
	}
}
