using Events.Db.Exceptions;
using Events.Db.Interfaces;
using Events.Db.Models.Aggregates;
using Events.Db.Models.Events;

namespace Events.Db.Repositories
{
    internal class GameEventRepository : IGameEventRespository
    {
        private readonly EventDbContext _dbContext;

        public GameEventRepository(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Game> CreateAggregate()
        {
            var game = new Game()
            {
                Version = 0
            };

            var entry = await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task PushEvent<T>(int aggregateId, string eventData)
        {
            var game = await _dbContext.Games.FindAsync(aggregateId);

            if (game == null)
            {
                throw DatabaseException.AggregateNotFound;
            }

            game.Version++;

            var newEvent = new GameEvent()
            {
                GameId = game.Id,
                Order = game.Version,
                EventType = nameof(T),
                EventData = eventData
            };

            await _dbContext.GameEvents.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();
        }
    }
}