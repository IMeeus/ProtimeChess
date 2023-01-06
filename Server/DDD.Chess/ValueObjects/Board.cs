using DDD.Chess.ValueObjects.Pieces;
using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    public class Board : ValueObject
    {
        private readonly Dictionary<Square, Piece?> _state;

        public Board(Dictionary<Square, Piece?> state)
        {
            _state = state;
        }

        public Dictionary<Square, Piece?> CopyState() => new(_state);

        public Piece? GetPieceOn(Square square)
        {
            return _state[square];
        }

        public King GetKingPiece(Color color)
        {
            return (King)_state.Values.Single(v => v is King && v.Color == color)!;
        }

        public Square GetKingSquare(Color color)
        {
            return _state.Single(kv => kv.Value is King && kv.Value.Color == color).Key;
        }

        public bool IsKingInCheck(Color color, List<Move> moveHistory)
        {
            var kingSquare = GetKingSquare(color);

            var enemySquarePieces = _state.Where(squarePiece => squarePiece.Value?.Color == color.GetOpposite());

            foreach (var squarePiece in enemySquarePieces)
            {
                var square = squarePiece.Key;
                var piece = squarePiece.Value;

                var validTargetSquares = piece!.GetValidTargetSquares(this, square, moveHistory);

                if (validTargetSquares.Any(square => square == kingSquare))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsKingInCheckMate(Color color, List<Move> moveHistory)
        {
            var kingPiece = GetKingPiece(color);
            var kingSquare = GetKingSquare(color);

            var kingValidTargetSquares = kingPiece.GetValidTargetSquares(this, kingSquare, moveHistory);
            var enemySquarePieces = _state.Where(squarePiece => squarePiece.Value?.Color == color.GetOpposite());

            bool hasSafeTargetSquares = false;
            foreach (var kingValidTargetSquare in kingValidTargetSquares)
            {
                bool canBeAttacked = false;
                foreach (var enemySquarePiece in enemySquarePieces)
                {
                    var enemySquare = enemySquarePiece.Key;
                    var enemyPiece = enemySquarePiece.Value;

                    var enemyValidTargetSquares = enemyPiece!.GetValidTargetSquares(this, enemySquare, moveHistory);

                    if (enemyValidTargetSquares.Any(square => square == kingValidTargetSquare))
                    {
                        canBeAttacked = true;
                    }
                }
                if (!canBeAttacked) hasSafeTargetSquares = true;
            }

            return hasSafeTargetSquares;
        }

        public Board MovePiece(Square startSquare, Square targetSquare)
        {
            var boardState = CopyState();

            var pieceOnStartSquare = GetPieceOn(startSquare);
            boardState[startSquare] = null;
            boardState[targetSquare] = pieceOnStartSquare;

            return new Board(boardState);
        }

        public Board RemovePiece(Square square)
        {
            var boardState = CopyState();

            boardState[square] = null;

            return new Board(boardState);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _state;
        }
    }
}