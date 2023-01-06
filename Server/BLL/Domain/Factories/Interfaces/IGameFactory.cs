using DDD.Chess.Aggregates;
using DDD.Chess.Identifiers;

namespace BLL.Domain.Factories.Interfaces
{
    internal interface IGameFactory
    {
        Task<Game> ConstructLatest(GameId gameId);
    }
}