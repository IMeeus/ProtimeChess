using BLL.Commands.CreateGame;
using BLL.Commands.StartGame;
using BLL.Queries.GetBoard;
using DDD.Chess.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/chess")]
    public class ChessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("game")]
        public async Task<IActionResult> CreateGame()
        {
            CreateGameCommand command = new();
            CreateGameResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("game/{id}/start")]
        public async Task<IActionResult> StartGame(int id)
        {
            StartGameCommand command = new(id);
            StartGameResponse response;

            try
            {
                response = await _mediator.Send(command);
            }
            catch (ChessException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(response);
        }

        [HttpGet("game/{id}/board")]
        public async Task<IActionResult> GetBoard(int id)
        {
            GetBoardQuery query = new(id);
            GetBoardResponse response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}