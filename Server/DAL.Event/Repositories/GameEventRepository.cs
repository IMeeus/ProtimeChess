using BLL.Interfaces;
using Events.Db.Exceptions;
using Microsoft.EntityFrameworkCore;
using Model.Aggregates;
using Model.Events;

namespace Events.Db.Repositories
{
    internal class GameEventRepository : IGameEventRepository
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

        public async Task<IEnumerable<GameEvent>> ListEventsFrom(int aggregateId)
        {
            return await _dbContext.GameEvents.Where(e => e.GameId == aggregateId).ToListAsync();
        }

        public async Task PushEvent(int aggregateId, string eventType, string eventData)
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
                EventType = eventType,
                EventData = eventData
            };

            await _dbContext.GameEvents.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();
        }
    }
}