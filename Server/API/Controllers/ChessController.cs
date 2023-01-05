using DDD.Chess.App.Commands.StartGame;
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

        [HttpPost("startGame")]
        public async Task<IActionResult> StartGame()
        {
            StartGameCommand request = new(1);
            StartGameResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}