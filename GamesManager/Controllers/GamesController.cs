using System.Net;
using GamesManager.Contracts.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using GamesManager.Contracts.Dto;
using GamesManager.Core.Exceptions;
using GamesManager.Core.Handlers.Commands.Games.CreateGame;
using GamesManager.Core.Handlers.Commands.Games.DeleteGame;
using GamesManager.Core.Handlers.Commands.Games.UpdateGame;
using GamesManager.Core.Handlers.Queries.Games.GetAllGames;
using GamesManager.Core.Handlers.Queries.Games.GetGameById;
using GamesManager.Core.Handlers.Queries.Games.GetGamesOrderedByGenre;
using MediatR;

namespace GamesManager.API.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class GamesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public GamesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		/// <summary>
		/// Get all games
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<GameDto>), (int)HttpStatusCode.OK)]
		[ProducesErrorResponseType(typeof(ResultResponseDto<GameDto>))]
		public async Task<IActionResult> Get()
		{
			var getAllGamesQuery = new GetAllGamesQuery();
			var response = await _mediator.Send(getAllGamesQuery);

			return Ok(response);
		}

		/// <summary>
		/// Insert game
		/// </summary>
		/// <param name="gameModel">Game request model</param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(typeof(GameDto), (int)HttpStatusCode.Created)]
		[ProducesErrorResponseType(typeof(ResultResponseDto<CreateOrUpdateGameDto>))]
		public async Task<IActionResult> Post([FromBody] CreateOrUpdateGameDto gameModel)
		{
			try
			{
				var createGameCommand = new CreateGameCommand(gameModel);
				var response = await _mediator.Send(createGameCommand);

				return StatusCode((int)HttpStatusCode.Created, response);
			}
			catch (InvalidRequestBodyException exception)
			{
				return BadRequest(new ResultResponseDto<CreateOrUpdateGameDto>()
				{
					IsSuccess = false,
					Errors = exception.Errors
				});
			}
		}

		/// <summary>
		/// Delete game
		/// </summary>
		/// <param name="gameId"></param>
		/// <returns></returns>
		[HttpDelete]
		[Route("{id}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesErrorResponseType(typeof(ResultResponseDto<GameDto>))]
		public async Task<IActionResult> Delete([FromRoute] Guid gameId)
		{
			var deleteGameCommand = new DeleteGameCommand(gameId);
			await _mediator.Send(deleteGameCommand);

			return Ok();
		}

		/// <summary>
		/// Update game
		/// </summary>
		/// <param name="id">Specified game id</param>
		/// <param name="gameModel">Updated game request model</param>
		/// <returns></returns>
		[HttpPut]
		[Route("{id}")]
		[ProducesResponseType(typeof(CreateOrUpdateGameDto), (int)HttpStatusCode.OK)]
		[ProducesErrorResponseType(typeof(ResultResponseDto<CreateOrUpdateGameDto>))]
		public async Task<IActionResult> Update(Guid id, [FromBody] CreateOrUpdateGameDto gameModel)
		{
			try
			{
				var updateGameCommand = new UpdateGameCommand(id, gameModel);
				var response = await _mediator.Send(updateGameCommand);

				return Ok(response);
			}
			catch (InvalidRequestBodyException exception)
			{
				return BadRequest(new ResultResponseDto<CreateOrUpdateGameDto>()
				{
					IsSuccess = false,
					Errors = exception.Errors
				});
			}
			catch (EntityNotFoundException exception)
			{
				return BadRequest(new ResultResponseDto<CreateOrUpdateGameDto>()
				{
					IsSuccess = false,
					Errors = new[] { exception.Message },
				});
			}
		}

		/// <summary>
		/// Get game by id
		/// </summary>
		/// <param name="gameId">Specified game id</param>
		/// <returns></returns>
		[HttpGet]
		[Route("{gameId}")]
		[ProducesResponseType(typeof(GameDto), (int)HttpStatusCode.OK)]
		[ProducesErrorResponseType(typeof(ResultResponseDto<GameDto>))]
		public async Task<IActionResult> GetById([FromRoute] Guid gameId)
		{
			try
			{
				var getGameByIdQuery = new GetGameByIdQuery(gameId);
				var response = await _mediator.Send(getGameByIdQuery);

				return Ok(response);
			}
			catch (EntityNotFoundException exception)
			{
				return NotFound(new ResultResponseDto<GameDto>()
				{
					IsSuccess = false,
					Errors = new[] { exception.Message },
				});
			}
		}

		/// <summary>
		/// Get games by genre
		/// </summary>
		/// <param name="gameGenre">Specified game genre</param>
		/// <returns></returns>
		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType(typeof(GameDto), (int)HttpStatusCode.OK)]
		[ProducesErrorResponseType(typeof(ResultResponseDto<GameDto>))]
		public async Task<IActionResult> GetByGenre(GameGenre gameGenre)
		{
			try
			{
				var getGamesOrderedByGenreQuery = new GetGamesOrderedByGenreQuery(gameGenre);
				var response = await _mediator.Send(getGamesOrderedByGenreQuery);

				return Ok(response);
			}
			catch (EntityNotFoundException exception)
			{
				return NotFound(new ResultResponseDto<GameDto>()
				{
					IsSuccess = false,
					Errors = new[] { exception.Message },
				});
			}
		}
	}
}
