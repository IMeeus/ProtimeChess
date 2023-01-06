using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    internal class Board : ValueObject
    {
        private readonly Dictionary<Square, Piece?> _state;

        public Board(Dictionary<Square, Piece?> state)
        {
            _state = state;
        }

        public Piece? GetPieceOnSquare(Square square)
        {
            return _state[square];
        }

        public Board MakeMove(Move move)
        {
            Dictionary<Square, Piece?> newBoardState = new(_state)
            {
                [move.StartSquare] = null,
                [move.TargetSquare] = _state[move.StartSquare],
            };

            return new Board(newBoardState);
        }

        public bool IsCheck(Color color)
        {
            //var king = _state.Where(kv => kv.Value is King && kv.Value.Color == Color.WHITE);
            return false;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _state;
        }
    }
}