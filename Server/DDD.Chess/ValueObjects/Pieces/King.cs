using DDD.Chess.Exceptions;
using DDD.Chess.ValueObjects.Pieces.Strategies;

namespace DDD.Chess.ValueObjects.Pieces
{
    public class King : Piece
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

        public IEnumerable<Square> GetValidTargetSquares(Board board, Square currentSquare, List<Move> moveHistory)
        {
            List<Square?> moveRange = new()
            {
                currentSquare.GetUp(),
                currentSquare.GetDown(),
                currentSquare.GetLeft(),
                currentSquare.GetRight(),
                currentSquare.GetUpLeft(),
                currentSquare.GetUpRight(),
                currentSquare.GetDownLeft(),
                currentSquare.GetDownRight()
            };

            List<Square> validTargetSquares = new();

            foreach (var square in moveRange)
            {
                if (square is null) continue;

                var pieceOnSquare = board.GetPieceOn(square);
                if (pieceOnSquare is null)
                {
                    validTargetSquares.Add(square);
                }
                else
                {
                    if (pieceOnSquare.Color != Color)
                    {
                        validTargetSquares.Add(square);
                    }

                    break;
                }
            }

            return validTargetSquares;
        }

        public Board Move(Board board, Move move, List<Move> moveHistory)
        {
            var validTargetSquares = GetValidTargetSquares(board, move.StartSquare, moveHistory);

            if (!validTargetSquares.Contains(move.TargetSquare))
            {
                throw ChessException.InvalidMove;
            }

            return board.MovePiece(move.StartSquare, move.TargetSquare);
        }
    }
}