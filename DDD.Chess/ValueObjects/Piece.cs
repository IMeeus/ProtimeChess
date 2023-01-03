using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    internal abstract class Piece : ValueObject
    {
        public Color Color { get; init; }
        public bool HasMoved { get; init; }

        public Piece(Color color, bool hasMoved = false)
        {
            Color = color;
            HasMoved = hasMoved;
        }

        public abstract IEnumerable<Square> GetMoveRange(Square currentSquare);

        public virtual IEnumerable<Square> GetAttackRange(Square currentSquare)
        {
            return GetMoveRange(currentSquare);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Color;
        }
    }
}