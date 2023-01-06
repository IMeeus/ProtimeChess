using DDD.Chess.ValueObjects;
using DDD.Core;

namespace DDD.Chess.DomainEvents
{
    public class MoveMade : DomainEvent
    {
        public Move Move { get; init; }

        public MoveMade(Move move)
        {
            Move = move;
        }
    }
}