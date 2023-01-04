using DDD.Chess.ValueObjects.Pieces.Strategies;

namespace DDD.Chess.ValueObjects.Pieces
{
    internal class King : Piece
    {
        private readonly IMoveStategy[] _moveStrategies = new IMoveStategy[]
        {
            new HorizontalMoveStrategy(MoveReach.ONE),
            new VerticalMoveStategy(MoveReach.ONE),
            new DiagonalMoveStrategy(MoveReach.ONE)
        };

        public King(Color color) : base(color)
        {
        }

        public override IEnumerable<Square> GetMoveRange(Square currentSquare)
        {
            return _moveStrategies.SelectMany(x => x.GetRange(currentSquare));
        }
    }
}