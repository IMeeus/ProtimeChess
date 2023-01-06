using DDD.Chess.Exceptions;
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

        public IEnumerable<Square> GetValidTargetSquares(Board board, Square currentSquare, List<Move> moveHistory)
        {
            IEnumerable<Square>[] moveRanges =
            {
                currentSquare.GetAllUp(),
                currentSquare.GetAllDown(),
                currentSquare.GetAllLeft(),
                currentSquare.GetAllRight(),
                currentSquare.GetAllUpLeft(),
                currentSquare.GetAllUpRight(),
                currentSquare.GetAllDownLeft(),
                currentSquare.GetAllDownRight()
            };

            List<Square> validTargetSquares = new();

            foreach (var moveRange in moveRanges)
            {
                foreach (var square in moveRange)
                {
                    var pieceOnSquare = board.GetPieceOn(square);
                    if (pieceOnSquare is null)
                    {
                        validTargetSquares.Add(square);
                    }
                    else if (pieceOnSquare.Color != Color)
                    {
                        validTargetSquares.Add(square);
                    }
                    else
                    {
                        break;
                    }
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