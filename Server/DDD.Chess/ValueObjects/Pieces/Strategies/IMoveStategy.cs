namespace DDD.Chess.ValueObjects.Pieces.Strategies
{
    internal interface IMoveStategy
    {
        public IEnumerable<Square> GetRange(Square fromSquare);
    }
}