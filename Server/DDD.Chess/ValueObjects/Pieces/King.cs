using DDD.Chess.Exceptions;

namespace DDD.Chess.ValueObjects.Pieces
{
    public class King : Piece
    {
        public King(Color color) : base(color)
        {
        }

        public override IEnumerable<Square> GetValidTargetSquares(Board board, Square currentSquare, List<Move> moveHistory)
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
                else if (pieceOnSquare.Color != Color)
                {
                    validTargetSquares.Add(square);
                }
            }

            return validTargetSquares;
        }

        public override Board Move(Board board, Move move, List<Move> moveHistory)
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