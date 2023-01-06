using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    public abstract class Piece : ValueObject
    {
        public Color Color { get; init; }

        public Piece(Color color)
        {
            Color = color;
        }

        public abstract IEnumerable<Square> GetValidTargetSquares(Board board, Square currentSquare, List<Move> moveHistory);

        public abstract Board Move(Board board, Move move, List<Move> moveHistory);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Color;
        }

        public override string ToString()
        {
            return $"{Color} {GetType().Name}";
        }
    }
}