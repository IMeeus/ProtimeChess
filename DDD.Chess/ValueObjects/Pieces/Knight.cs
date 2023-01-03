using DDD.Chess.ValueObjects.Pieces.Strategies;

namespace DDD.Chess.ValueObjects.Pieces
{
    internal class Knight : Piece
    {
        private readonly IMoveStategy _moveStategy = new KnightMoveStrategy();

        public Knight(Color color) : base(color)
        {
        }

        public override IEnumerable<Square> GetMoveRange(Square currentSquare)
        {
            return _moveStategy.GetRange(currentSquare);
        }
    }
}