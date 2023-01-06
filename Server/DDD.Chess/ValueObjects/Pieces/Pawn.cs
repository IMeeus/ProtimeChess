using DDD.Chess.Exceptions;
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

        public IEnumerable<Square> GetValidTargetSquares(Board board, Square currentSquare, List<Move> moveHistory)
        {
            List<Square> validTargetSquares = new();

            if (Color == Color.WHITE)
            {
                var upSquare = currentSquare.GetUp();
                if (upSquare is not null)
                {
                    validTargetSquares.Add(upSquare);
                }

                var upLeftSquare = currentSquare.GetUpLeft();
                if (upLeftSquare is not null)
                {
                    var pieceOnSquare = board.GetPieceOn(upLeftSquare);
                    if (pieceOnSquare is not null
                        && pieceOnSquare.Color == Color.BLACK)
                    {
                        validTargetSquares.Add(upLeftSquare);
                    }
                }

                var upRightSquare = currentSquare.GetUpRight();
                if (upRightSquare is not null)
                {
                    var pieceOnSquare = board.GetPieceOn(upRightSquare);
                    if (pieceOnSquare is not null
                        && pieceOnSquare.Color == Color.BLACK)
                    {
                        validTargetSquares.Add(upRightSquare);
                    }
                }

                // Double Up
                if (currentSquare.Rank == Rank.TWO)
                {
                    var hasMoved = moveHistory.Any(move => move.StartSquare == currentSquare);
                    if (!hasMoved)
                    {
                        var doubleUpSquare = currentSquare.GetUp()!.GetUp()!;
                        validTargetSquares.Add(doubleUpSquare);
                    }
                }

                // En Passant Left
                var leftSquare = currentSquare.GetLeft();
                if (leftSquare is not null)
                {
                    var lastMove = moveHistory.LastOrDefault();
                    var leftPiece = board.GetPieceOn(leftSquare);
                    if (leftPiece is Piece
                        && lastMove is not null
                        && lastMove.StartSquare.Rank == Rank.SEVEN
                        && lastMove.TargetSquare == leftSquare)
                    {
                        var enPassantSquare = currentSquare.GetUpLeft()!;
                        validTargetSquares.Add(enPassantSquare);
                    }
                }

                // En Passant Right
                var rightSquare = currentSquare.GetRight();
                if (rightSquare is not null)
                {
                    var lastMove = moveHistory.LastOrDefault();
                    var rightPiece = board.GetPieceOn(rightSquare);
                    if (rightPiece is Piece
                        && lastMove is not null
                        && lastMove.StartSquare.Rank == Rank.SEVEN
                        && lastMove.TargetSquare == rightSquare)
                    {
                        var enPassantSquare = currentSquare.GetUpRight()!;
                        validTargetSquares.Add(enPassantSquare);
                    }
                }
            }

            if (Color == Color.BLACK)
            {
                var downSquare = currentSquare.GetDown();
                if (downSquare is not null)
                {
                    validTargetSquares.Add(downSquare);
                }

                var downLeftSquare = currentSquare.GetDownLeft();
                if (downLeftSquare is not null)
                {
                    var pieceOnSquare = board.GetPieceOn(downLeftSquare);
                    if (pieceOnSquare is not null
                        && pieceOnSquare.Color == Color.BLACK)
                    {
                        validTargetSquares.Add(downLeftSquare);
                    }
                }

                var downRightSquare = currentSquare.GetDownRight();
                if (downRightSquare is not null)
                {
                    var pieceOnSquare = board.GetPieceOn(downRightSquare);
                    if (pieceOnSquare is not null
                        && pieceOnSquare.Color == Color.BLACK)
                    {
                        validTargetSquares.Add(downRightSquare);
                    }
                }

                // Double Up
                if (currentSquare.Rank == Rank.SEVEN)
                {
                    var hasMoved = moveHistory.Any(move => move.StartSquare == currentSquare);
                    if (!hasMoved)
                    {
                        var doubleUpSquare = currentSquare.GetUp()!.GetUp()!;
                        validTargetSquares.Add(doubleUpSquare);
                    }
                }

                // En Passant Left
                var leftSquare = currentSquare.GetLeft();
                if (leftSquare is not null)
                {
                    var lastMove = moveHistory.LastOrDefault();
                    var leftPiece = board.GetPieceOn(leftSquare);
                    if (leftPiece is Piece
                        && lastMove is not null
                        && lastMove.StartSquare.Rank == Rank.TWO
                        && lastMove.TargetSquare == leftSquare)
                    {
                        var enPassantSquare = currentSquare.GetDownLeft()!;
                        validTargetSquares.Add(enPassantSquare);
                    }
                }

                // En Passant Right
                var rightSquare = currentSquare.GetRight();
                if (rightSquare is not null)
                {
                    var lastMove = moveHistory.LastOrDefault();
                    var rightPiece = board.GetPieceOn(rightSquare);
                    if (rightPiece is Piece
                        && lastMove is not null
                        && lastMove.StartSquare.Rank == Rank.TWO
                        && lastMove.TargetSquare == rightSquare)
                    {
                        var enPassantSquare = currentSquare.GetDownRight()!;
                        validTargetSquares.Add(enPassantSquare);
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

            // En Passant
            var pieceOnTargetSquare = board.GetPieceOn(move.TargetSquare);
            if (pieceOnTargetSquare is null
                && move.StartSquare.File != move.TargetSquare.File)
            {
                var rightSquare = move.StartSquare.GetRight();
                if (rightSquare is not null && rightSquare.File == move.TargetSquare.File)
                {
                    newBoard = newBoard.RemovePiece(rightSquare);
                }

                var leftSquare = move.StartSquare.GetLeft();
                if (leftSquare is not null && leftSquare.File == move.TargetSquare.File)
                {
                    newBoard = newBoard.RemovePiece(leftSquare);
                }
            }

            return newBoard;
        }
    }
}