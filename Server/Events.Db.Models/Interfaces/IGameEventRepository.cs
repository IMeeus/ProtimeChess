using Events.Db.Models.Aggregates;
using Events.Db.Models.Events;

namespace DDD.Chess.App.Interfaces
{
    public interface IGameEventRepository
    {
        Task<Game> CreateAggregate();

        Task PushEvent(int aggregateId, string eventType, string eventData);

        Task<IEnumerable<GameEvent>> ListEventsFrom(int aggregateId);
    }
}