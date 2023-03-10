using BLL.Domain.Factories;
using BLL.Infrastructure.Interfaces;
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

        public StartGameHandler(IGameEventRepository gameEventRepository, GameFactory gameFactory)
        {
            _gameEventRepository = gameEventRepository;
            _gameFactory = gameFactory;
        }

        public async Task<StartGameResponse> Handle(StartGameCommand request, CancellationToken cancellationToken)
        {
            GameId gameId = new(request.GameId);

            Game game = await _gameFactory.ConstructLatest(gameId);
            game.Start();

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