﻿using DDD.Chess.Aggregates;
using DDD.Chess.App.Interfaces;
using DDD.Chess.Identifiers;
using DDD.Core;
using Newtonsoft.Json;

namespace DDD.Chess.App.AggregateFactories
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
            var gameEvents = await _eventRepository.ListEventsFrom(gameId.Value);

            IEnumerable<DomainEvent> domainEvents = gameEvents.Select(e => JsonConvert.DeserializeObject<DomainEvent>(e.EventData));

            return new Game(gameId, domainEvents);
        }
    }
}