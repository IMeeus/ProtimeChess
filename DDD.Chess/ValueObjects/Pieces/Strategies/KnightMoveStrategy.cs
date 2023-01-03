namespace DDD.Chess.ValueObjects.Pieces.Strategies
{
    internal class KnightMoveStrategy : IMoveStategy
    {
        public IEnumerable<Square> GetRange(Square fromSquare)
        {
            var fileIndex = fromSquare.File.Index;
            var rankIndex = fromSquare.Rank.Index;

            if (File.IsValidIndex(fileIndex - 2))
            {
                var newFile = File.WithIndex(fileIndex - 2);
                if (Rank.IsValidIndex(rankIndex - 1))
                {
                    var newRank = Rank.WithIndex(rankIndex - 1);
                    yield return new Square(newFile, newRank);
                }
                if (Rank.IsValidIndex(rankIndex + 1))
                {
                    var newRank = Rank.WithIndex(rankIndex + 1);
                    yield return new Square(newFile, newRank);
                }
            }

            if (File.IsValidIndex(fileIndex + 2))
            {
                var newFile = File.WithIndex(fileIndex + 2);
                if (Rank.IsValidIndex(rankIndex - 1))
                {
                    var newRank = Rank.WithIndex(rankIndex - 1);
                    yield return new Square(newFile, newRank);
                }
                if (Rank.IsValidIndex(rankIndex + 1))
                {
                    var newRank = Rank.WithIndex(rankIndex + 1);
                    yield return new Square(newFile, newRank);
                }
            }

            if (Rank.IsValidIndex(rankIndex - 2))
            {
                var newRank = Rank.WithIndex(rankIndex - 2);
                if (File.IsValidIndex(fileIndex - 1))
                {
                    var newFile = File.WithIndex(fileIndex - 1);
                    yield return new Square(newFile, newRank);
                }
                if (File.IsValidIndex(fileIndex + 1))
                {
                    var newFile = File.WithIndex(fileIndex + 1);
                    yield return new Square(newFile, newRank);
                }
            }

            if (Rank.IsValidIndex(rankIndex + 2))
            {
                var newRank = Rank.WithIndex(rankIndex + 2);
                if (File.IsValidIndex(fileIndex - 1))
                {
                    var newFile = File.WithIndex(fileIndex - 1);
                    yield return new Square(newFile, newRank);
                }
                if (File.IsValidIndex(fileIndex + 1))
                {
                    var newFile = File.WithIndex(fileIndex + 1);
                    yield return new Square(newFile, newRank);
                }
            }
        }
    }
}