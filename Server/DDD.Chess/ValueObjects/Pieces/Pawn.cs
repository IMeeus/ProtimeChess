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

                // Move 2
                //if (currentSquare.Rank == Rank.TWO)
                //{
                //    var hasMoved = moveHistory.Any(move => move.StartSquare == currentSquare);
                //    if (!hasMoved)
                //    {
                //    }
                //}

                // En Passant
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
            }

            return validTargetSquares;
        }
    }
}