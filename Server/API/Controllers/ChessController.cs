using BLL.Commands.CreateGame;
using BLL.Commands.StartGame;
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

        [HttpPost("createGame")]
        public async Task<IActionResult> CreateGame()
        {
            CreateGameCommand command = new();
            CreateGameResponse response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("startGame")]
        public async Task<IActionResult> StartGame()
        {
            StartGameCommand command = new(1);
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
    }
}