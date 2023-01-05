namespace DDD.Chess.ValueObjects
{
    public class Move
    {
        public Square StartSquare { get; init; }
        public Square TargetSquare { get; init; }

        public Move(Square startSquare, Square endSquare)
        {
            StartSquare = startSquare;
            TargetSquare = endSquare;
        }
    }
}