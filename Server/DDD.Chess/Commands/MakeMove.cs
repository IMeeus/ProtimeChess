using DDD.Chess.ValueObjects;

namespace DDD.Chess.Commands
{
    public class MakeMove
    {
        public Move Move { get; init; }

        public MakeMove(Move move)
        {
            Move = move;
        }
    }
}