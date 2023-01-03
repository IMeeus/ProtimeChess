namespace DDD.Chess.ValueObjects.Pieces.Strategies
{
    internal class HorizontalMoveStrategy : IMoveStategy
    {
        private readonly MoveReach _reach;

        public HorizontalMoveStrategy(MoveReach reach)
        {
            _reach = reach;
        }

        public IEnumerable<Square> GetRange(Square fromSquare)
        {
            int fileIndex = fromSquare.File.Index;

            int minFileIndex = 0;
            int maxFileIndex = File.Values.Count() - 1;

            if (fileIndex + 1 < maxFileIndex)
            {
                if (_reach == MoveReach.ONE)
                {
                    var newFile = File.WithIndex(fileIndex + 1);
                    yield return new Square(newFile, fromSquare.Rank);
                }
                else
                {
                    for (int i = fileIndex + 1; i <= maxFileIndex; i++)
                    {
                        var newFile = File.WithIndex(i);
                        yield return new Square(newFile, fromSquare.Rank);
                    }
                }
            }

            if (fileIndex - 1 >= minFileIndex)
            {
                if (_reach == MoveReach.ONE)
                {
                    var newFile = File.WithIndex(fileIndex - 1);
                    yield return new Square(newFile, fromSquare.Rank);
                }
                else
                {
                    for (int i = minFileIndex; i <= fileIndex - 1; i++)
                    {
                        var newFile = File.WithIndex(i);
                        yield return new Square(newFile, fromSquare.Rank);
                    }
                }
            }
        }
    }
}