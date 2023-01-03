using DDD.Chess.ValueObjects.Pieces.Strategies;

namespace DDD.Chess.ValueObjects.Pieces
{
    internal class Pawn : Piece
    {
        public Pawn(Color color) : base(color)
        {
        }

        public override IEnumerable<Square> GetMoveRange(Square currentSquare)
        {
            return new VerticalMoveStategy(MoveReach.ONE).GetRange(currentSquare);
        }

        public override IEnumerable<Square> GetAttackRange(Square currentSquare)
        {
            MoveDirection direction = Color == Color.WHITE ? MoveDirection.UP : MoveDirection.DOWN;
            return new DiagonalMoveStrategy(MoveReach.ONE, direction).GetRange(currentSquare);
        }
    }
}