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

        public King GetKing(Color color)
        {
            return (King)_state.Values.Single(v => v is King && v.Color == color)!;
        }

        public Square GetKingSquare(Color color)
        {
            return _state.Single(kv => kv.Value is King && kv.Value.Color == color).Key;
        }

        public bool IsCheck(Color color)
        {
            //var king = _state.Where(kv => kv.Value is King && kv.Value.Color == Color.WHITE);
            return false;
        }

        public Board MovePiece(Square startSquare, Square targetSquare)
        {
            var boardState = CopyState();

            var pieceOnStartSquare = GetPieceOn(startSquare);
            boardState[startSquare] = null;
            boardState[targetSquare] = pieceOnStartSquare;

            return new Board(boardState);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _state;
        }
    }
}