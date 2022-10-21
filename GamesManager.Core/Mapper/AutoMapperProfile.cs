using GamesManager.Contracts.Data.Entities;
using GamesManager.Contracts.Dto;
using AutoMapper;

namespace GamesManager.Core.Mapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Game, Game>()
				.ForMember(game => game.Id, options => options.Ignore());

			CreateMap<Game, GameDto>();

			CreateMap<GameDto, Game>()
				.ForMember(
					game => game.GameGenres,
					options => options.MapFrom(gameModel => gameModel.GameGenres.ToList()))
				.ReverseMap();

			CreateMap<DeveloperStudio, DeveloperStudio>()
				.ForMember(developerStudio => developerStudio.Id, options => options.Ignore());

			CreateMap<CreateOrUpdateGameDto, Game>()
				.ForMember(
					game => game.GameGenres,
					options => options.MapFrom(gameModel => gameModel.GameGenres.ToList()));

			CreateMap<CreateOrUpdateDeveloperStudioDto, DeveloperStudio>();
		}
	}
}
