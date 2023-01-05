using Events.Db.Models.Aggregates;

namespace Events.Db.Interfaces
{
    public interface IGameEventRespository
    {
        public Task<Game> CreateAggregate();

        public Task PushEvent<T>(int aggragateId, string eventData);
    }
}