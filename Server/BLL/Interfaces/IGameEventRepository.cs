using Model.Aggregates;
using Model.Events;

namespace BLL.Interfaces
{
    public interface IGameEventRepository
    {
        Task<Game> CreateAggregate();

        Task PushEvent(int aggregateId, string eventType, string eventData);

        Task<IEnumerable<GameEvent>> ListEventsOf(int aggregateId);
    }
}