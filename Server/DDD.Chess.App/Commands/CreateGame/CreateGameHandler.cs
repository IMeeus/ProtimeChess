using Events.Db.Interfaces;
using MediatR;

namespace DDD.Chess.App.Commands.CreateGame
{
    internal class CreateGameHandler : IRequestHandler<CreateGameCommand, CreateGameResponse>
    {
        private readonly IGameEventRespository _gameEventRepository;

        public CreateGameHandler(IGameEventRespository gameEventRepository)
        {
            _gameEventRepository = gameEventRepository;
        }

        public async Task<CreateGameResponse> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var newGame = await _gameEventRepository.CreateAggregate();

            return new CreateGameResponse(newGame.Id);
        }
    }
}