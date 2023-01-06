using DDD.Chess.Exceptions;

namespace DDD.Chess.ValueObjects.Pieces
{
    internal class Knight : Piece
    {
        public Knight(Color color) : base(color, canJump: true)
        {
        }

        public override IEnumerable<Square> GetValidTargetSquares(Board board, Square currentSquare, List<Move> moveHistory)
        {
            List<Square?> moveRange = new()
            {
                currentSquare.GetUp()?.GetUpLeft(),
                currentSquare.GetUp()?.GetUpRight(),
                currentSquare.GetLeft()?.GetUpLeft(),
                currentSquare.GetLeft()?.GetDownLeft(),
                currentSquare.GetRight()?.GetUpRight(),
                currentSquare.GetRight()?.GetDownRight(),
                currentSquare.GetDown()?.GetDownLeft(),
                currentSquare.GetDown()?.GetDownRight()
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