namespace DDD.Chess.ValueObjects.Pieces.Strategies
{
    internal class VerticalMoveStategy : IMoveStategy
    {
        private readonly MoveReach _reach;

        public VerticalMoveStategy(MoveReach reach)
        {
            _reach = reach;
        }

        public IEnumerable<Square> GetRange(Square fromSquare)
        {
            int rankIndex = fromSquare.Rank.Index;

            int minRankIndex = 0;
            int maxRankIndex = Rank.Values.Count() - 1;

            if (rankIndex + 1 <= maxRankIndex)
            {
                if (_reach == MoveReach.ONE)
                {
                    var newRank = Rank.WithIndex(rankIndex + 1);
                    yield return new Square(fromSquare.File, newRank);
                }
                else
                {
                    for (int i = rankIndex + 1; i <= maxRankIndex; i++)
                    {
                        var newRank = Rank.WithIndex(i);
                        yield return new Square(fromSquare.File, newRank);
                    }
                }
            }

            if (rankIndex - 1 >= minRankIndex)
            {
                if (_reach == MoveReach.ONE)
                {
                    var newRank = Rank.WithIndex(rankIndex - 1);
                    yield return new Square(fromSquare.File, newRank);
                }
                else
                {
                    for (int i = minRankIndex; i <= rankIndex - 1; i++)
                    {
                        var newRank = Rank.WithIndex(i);
                        yield return new Square(fromSquare.File, newRank);
                    }
                }
            }
        }
    }
}