using DDD.Chess.ValueObjects.Pieces.Strategies;

namespace DDD.Chess.ValueObjects.Pieces
{
    internal class Rook : Piece
    {
        public Rook(Color color) : base(color)
        {
        }

        public override IEnumerable<Square> GetMoveRange(Square currentSquare)
        {
            var moveStrategies = new IMoveStategy[]
            {
                new HorizontalMoveStrategy(MoveReach.UNLIMITED),
                new VerticalMoveStategy(MoveReach.UNLIMITED)
            };

            return moveStrategies.SelectMany(s => s.GetRange(currentSquare));
        }
    }
}