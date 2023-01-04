namespace DDD.Chess.ValueObjects.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color) : base(color)
        {
        }

        public override IEnumerable<Square> GetMoveRange(Square fromSquare)
        {
            IEnumerable<Square>[] ranges =
            {
                fromSquare.AllUpLeft(),
                fromSquare.AllUpRight(),
                fromSquare.AllDownLeft(),
                fromSquare.AllDownRight()
            };

            return ranges.SelectMany(x => x);
        }
    }
}