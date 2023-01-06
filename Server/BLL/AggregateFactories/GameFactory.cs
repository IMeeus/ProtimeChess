using BLL.Interfaces;
using DDD.Chess.Aggregates;
using DDD.Chess.Identifiers;
using DDD.Core;
using Newtonsoft.Json;

namespace BLL.AggregateFactories
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

            IEnumerable<DomainEvent> domainEvents = gameEvents.Select(e => JsonConvert.DeserializeObject<DomainEvent>(e.EventData));

            return new Game(gameId, domainEvents);
        }
    }
}