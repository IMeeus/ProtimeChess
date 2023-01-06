using BLL.Infrastructure.Interfaces;
using DDD.Chess.Aggregates;
using DDD.Chess.Identifiers;
using DDD.Core;
using Newtonsoft.Json;

namespace BLL.Domain.Factories
{
    internal class GameFactory
    {
        private readonly IGameEventRepository _eventRepository;

        public GameFactory(IGameEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Game> ConstructLatest(GameId gameId)
        {
            var gameEvents = await _eventRepository.ListEventsOf(gameId.Value);

            IEnumerable<DomainEvent> domainEvents = gameEvents.Select(e =>
            {
                var domainAssembly = "DDD.Chess";
                var eventClassName = $"{domainAssembly}.DomainEvents.{e.EventType}";

                Type? eventType = Type.GetType($"{eventClassName}, {domainAssembly}");

                if (eventType is null) throw new InvalidCastException();

                return (DomainEvent)JsonConvert.DeserializeObject(e.EventData, eventType);
            });

            var newGame = new Game(gameId, domainEvents);

            return newGame;
        }
    }
}