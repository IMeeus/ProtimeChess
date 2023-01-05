using MediatR;

namespace DDD.Chess.App.Commands.StartGame
{
    internal class StartGameHandler : IRequestHandler<StartGameCommand, StartGameResponse>
    {
        public Task<StartGameResponse> Handle(StartGameCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new StartGameResponse(true));
        }
    }
}