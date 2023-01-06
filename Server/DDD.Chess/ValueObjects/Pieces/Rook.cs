using DDD.Chess.Exceptions;
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

        public IEnumerable<Square> GetValidTargetSquares(Board board, Square currentSquare, List<Move> moveHistory)
        {
            IEnumerable<Square>[] moveRanges =
            {
                currentSquare.GetAllUp(),
                currentSquare.GetAllDown(),
                currentSquare.GetAllLeft(),
                currentSquare.GetAllRight()
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
                    else
                    {
                        if (pieceOnSquare.Color != Color)
                        {
                            validTargetSquares.Add(square);
                        }

                        break;
                    }
                }
            }

            // TODO: Check if king square + intermediates are in check

            if (Color == Color.WHITE)
            {
                // Castling: A1 to D1
                if (currentSquare == new Square(File.A, Rank.ONE))
                {
                    var rookHasMoved = moveHistory.Any(move => move.StartSquare == new Square(File.A, Rank.ONE));
                    var kingHasMoved = moveHistory.Any(move => move.StartSquare == new Square(File.E, Rank.ONE));

                    if (rookHasMoved || kingHasMoved)
                    {
                        validTargetSquares.Remove(new Square(File.D, Rank.ONE));
                    }
                }

                // Castling: H1 to F1
                if (currentSquare == new Square(File.H, Rank.ONE))
                {
                    var rookHasMoved = moveHistory.Any(move => move.StartSquare == new Square(File.H, Rank.ONE));
                    var kingHasMoved = moveHistory.Any(move => move.StartSquare == new Square(File.E, Rank.ONE));

                    if (rookHasMoved || kingHasMoved)
                    {
                        validTargetSquares.Remove(new Square(File.F, Rank.ONE));
                    }
                }
            }

            if (Color == Color.BLACK)
            {
                // Castling: A8 to D8
                if (currentSquare == new Square(File.A, Rank.EIGHT))
                {
                    var rookHasMoved = moveHistory.Any(move => move.StartSquare == new Square(File.A, Rank.EIGHT));
                    var kingHasMoved = moveHistory.Any(move => move.StartSquare == new Square(File.E, Rank.EIGHT));

                    if (rookHasMoved || kingHasMoved)
                    {
                        validTargetSquares.Remove(new Square(File.D, Rank.EIGHT));
                    }
                }

                // Castling: H8 to F8
                if (currentSquare == new Square(File.H, Rank.EIGHT))
                {
                    var rookHasMoved = moveHistory.Any(move => move.StartSquare == new Square(File.H, Rank.EIGHT));
                    var kingHasMoved = moveHistory.Any(move => move.StartSquare == new Square(File.E, Rank.EIGHT));

                    if (rookHasMoved || kingHasMoved)
                    {
                        validTargetSquares.Remove(new Square(File.F, Rank.EIGHT));
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

            var newBoard = board.MovePiece(move.StartSquare, move.TargetSquare);

            if (Color == Color.WHITE)
            {
                var whiteKingSquare = board.GetKingSquare(Color.WHITE);

                if (move.StartSquare == new Square(File.A, Rank.ONE)
                    && move.TargetSquare == new Square(File.D, Rank.ONE)
                    && whiteKingSquare == new Square(File.E, Rank.ONE))
                {
                    newBoard = newBoard.MovePiece(whiteKingSquare, new Square(File.C, Rank.ONE));
                }

                if (move.StartSquare == new Square(File.H, Rank.ONE)
                    && move.TargetSquare == new Square(File.F, Rank.ONE)
                    && whiteKingSquare == new Square(File.E, Rank.ONE))
                {
                    newBoard = newBoard.MovePiece(whiteKingSquare, new Square(File.G, Rank.ONE));
                }
            }

            if (Color == Color.BLACK)
            {
                var blackKingSquare = board.GetKingSquare(Color.BLACK);

                if (move.StartSquare == new Square(File.A, Rank.EIGHT)
                    && move.TargetSquare == new Square(File.D, Rank.EIGHT)
                    && blackKingSquare == new Square(File.E, Rank.EIGHT))
                {
                    newBoard = newBoard.MovePiece(blackKingSquare, new Square(File.C, Rank.ONE));
                }

                if (move.StartSquare == new Square(File.H, Rank.EIGHT)
                    && move.TargetSquare == new Square(File.F, Rank.EIGHT)
                    && blackKingSquare == new Square(File.E, Rank.EIGHT))
                {
                    newBoard = newBoard.MovePiece(blackKingSquare, new Square(File.G, Rank.EIGHT));
                }
            }

            return newBoard;
        }
    }
}