using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    internal class Board : ValueObject
    {
        public Dictionary<Square, Piece?> State { get; init; }

        public Board(Dictionary<Square, Piece?> state)
        {
            State = state;
        }

        public Piece? GetPieceOnSquare(Square square)
        {
            return State[square];
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return State;
        }
    }
}