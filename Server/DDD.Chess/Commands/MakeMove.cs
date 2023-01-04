using DDD.Chess.ValueObjects;

namespace DDD.Chess.Commands
{
    internal class MakeMove
    {
        public Move Move { get; init; }

        public MakeMove(Move move)
        {
            Move = move;
        }
    }
}