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
                fromSquare.GetAllUpLeft(),
                fromSquare.GetAllUpRight(),
                fromSquare.GetAllDownLeft(),
                fromSquare.GetAllDownRight()
            };

            return ranges.SelectMany(x => x);
        }
    }
}