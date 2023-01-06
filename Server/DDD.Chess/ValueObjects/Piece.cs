using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    public abstract class Piece : ValueObject
    {
        public Color Color { get; init; }
        public bool HasMoved { get; init; }
        public bool CanJump { get; set; }

        public Piece(Color color, bool hasMoved = false, bool canJump = false)
        {
            Color = color;
            HasMoved = hasMoved;
            CanJump = canJump;
        }

        public abstract IEnumerable<Square> GetMoveRange(Square fromSquare);

        public virtual IEnumerable<Square> GetAttackRange(Square fromSquare)
        {
            return GetMoveRange(fromSquare);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Color;
        }
    }
}