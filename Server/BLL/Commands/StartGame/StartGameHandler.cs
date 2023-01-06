using BLL.AggregateFactories;
using BLL.Interfaces;
using DDD.Chess.Aggregates;
using DDD.Chess.Identifiers;
using MediatR;
using Newtonsoft.Json;

namespace BLL.Commands.StartGame
{
    internal class StartGameHandler : IRequestHandler<StartGameCommand, StartGameResponse>
    {
        private readonly IGameEventRepository _gameEventRepository;
        private readonly GameFactory _gameFactory;

        public StartGameHandler(IGameEventRepository gameEventRepository)
        {
            _gameEventRepository = gameEventRepository;
            _gameFactory = new GameFactory(_gameEventRepository);
        }

        public async Task<StartGameResponse> Handle(StartGameCommand request, CancellationToken cancellationToken)
        {
            GameId gameId = new(request.GameId);

            Game game = await _gameFactory.ConstructLatest(gameId);

            foreach (var @event in game.Events)
            {
                var eventType = @event.GetType().Name;
                var eventData = JsonConvert.SerializeObject(@event);

                await _gameEventRepository.PushEvent(gameId.Value, eventType, eventData);
            }

            return new StartGameResponse(true);
        }
    }
}