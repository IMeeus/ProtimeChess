using DDD.Chess.ValueObjects.Pieces.Strategies;

namespace DDD.Chess.ValueObjects.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Color color) : base(color)
        {
        }

        public override IEnumerable<Square> GetMoveRange(Square currentSquare)
        {
            var strategies = new IMoveStategy[]
            {
                new HorizontalMoveStrategy(MoveReach.UNLIMITED),
                new VerticalMoveStategy(MoveReach.UNLIMITED),
                new DiagonalMoveStrategy(MoveReach.UNLIMITED)
            };

            return strategies.SelectMany(s => s.GetRange(currentSquare));
        }
    }
}