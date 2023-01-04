namespace DDD.Chess.ValueObjects.Pieces.Strategies
{
    internal class DiagonalMoveStrategy : IMoveStategy
    {
        private readonly MoveReach _reach;
        private readonly MoveDirection? _direction;

        public DiagonalMoveStrategy(MoveReach reach)
        {
            _reach = reach;
        }

        public DiagonalMoveStrategy(MoveReach reach, MoveDirection direction)
        {
            _reach = reach;
            _direction = direction;
        }

        public IEnumerable<Square> GetRange(Square fromSquare)
        {
            var fileIndex = fromSquare.File.Index;
            var minFileIndex = 0;
            var maxFileIndex = File.Values.Count() - 1;

            var rankIndex = fromSquare.Rank.Index;
            var minRankIndex = 0;
            var maxRankIndex = Rank.Values.Count() - 1;

            if (_direction is null || _direction == MoveDirection.UP)
            {
                // LEFT-UP
                if (fileIndex > minFileIndex && rankIndex < maxRankIndex)
                {
                    if (_reach == MoveReach.ONE)
                    {
                        var newFile = File.WithIndex(fileIndex - 1);
                        var newRank = Rank.WithIndex(rankIndex + 1);
                        yield return new Square(newFile, newRank);
                    }
                    else
                    {
                        var fileRange = fileIndex - minFileIndex;
                        var rankRange = maxRankIndex - rankIndex;
                        var smallestRange = fileRange <= rankRange ? fileRange : rankRange;

                        for (int i = 1; i <= smallestRange; i++)
                        {
                            var newFile = File.WithIndex(fileIndex - i);
                            var newRank = Rank.WithIndex(rankIndex + i);
                            yield return new Square(newFile, newRank);
                        }
                    }
                }

                // RIGHT-UP
                if (fileIndex < maxFileIndex && rankIndex < maxRankIndex)
                {
                    if (_reach == MoveReach.ONE)
                    {
                        var newFile = File.WithIndex(fileIndex + 1);
                        var newRank = Rank.WithIndex(rankIndex + 1);
                        yield return new Square(newFile, newRank);
                    }
                    else
                    {
                        var fileRange = maxFileIndex - fileIndex;
                        var rankRange = maxRankIndex - rankIndex;
                        var smallestRange = fileRange <= rankRange ? fileRange : rankRange;

                        for (int i = 1; i <= smallestRange; i++)
                        {
                            var newFile = File.WithIndex(fileIndex + i);
                            var newRank = Rank.WithIndex(rankIndex + i);
                            yield return new Square(newFile, newRank);
                        }
                    }
                }
            }

            if (_direction is null || _direction == MoveDirection.DOWN)
            {
                // LEFT-DOWN
                if (fileIndex > minFileIndex && rankIndex > minRankIndex)
                {
                    if (_reach == MoveReach.ONE)
                    {
                        var newFile = File.WithIndex(fileIndex - 1);
                        var newRank = Rank.WithIndex(rankIndex - 1);
                        yield return new Square(newFile, newRank);
                    }
                    else
                    {
                        var fileRange = fileIndex - minFileIndex;
                        var rankRange = rankIndex - minRankIndex;
                        var smallestRange = fileRange <= rankRange ? fileRange : rankRange;

                        for (int i = 1; i <= smallestRange; i++)
                        {
                            var newFile = File.WithIndex(fileIndex - i);
                            var newRank = Rank.WithIndex(rankIndex - i);
                            yield return new Square(newFile, newRank);
                        }
                    }
                }

                // RIGHT-DOWN
                if (fileIndex < maxFileIndex && rankIndex > minRankIndex)
                {
                    if (_reach == MoveReach.ONE)
                    {
                        var newFile = File.WithIndex(fileIndex + 1);
                        var newRank = Rank.WithIndex(rankIndex - 1);
                        yield return new Square(newFile, newRank);
                    }
                    else
                    {
                        var fileRange = maxFileIndex - fileIndex;
                        var rankRange = rankIndex - minRankIndex;
                        var smallestRange = fileRange <= rankRange ? fileRange : rankRange;

                        for (int i = 1; i <= smallestRange; i++)
                        {
                            var newFile = File.WithIndex(fileIndex + i);
                            var newRank = Rank.WithIndex(rankIndex - i);
                            yield return new Square(newFile, newRank);
                        }
                    }
                }
            }
        }
    }
}