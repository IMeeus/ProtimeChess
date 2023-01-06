using BLL.Interfaces;
using MediatR;
using Model.Aggregates;

namespace BLL.Commands.CreateGame
{
    internal class CreateGameHandler : IRequestHandler<CreateGameCommand, CreateGameResponse>
    {
        private readonly IGameEventRepository _gameEventRepository;

        public CreateGameHandler(IGameEventRepository gameEventRepository)
        {
            _gameEventRepository = gameEventRepository;
        }

        public async Task<CreateGameResponse> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            Game newGame = await _gameEventRepository.CreateAggregate();
            return new CreateGameResponse(newGame.Id);
        }
    }
}