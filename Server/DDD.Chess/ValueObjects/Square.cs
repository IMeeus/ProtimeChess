using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    public class Square : ValueObject
    {
        public File File { get; init; }
        public Rank Rank { get; init; }

        public Square(File file, Rank rank)
        {
            File = file;
            Rank = rank;
        }

        public Square? GetUp()
        {
            var newRankIndex = Rank.Index + 1;
            if (Rank.IsValidIndex(newRankIndex))
            {
                return new Square(File, Rank.WithIndex(newRankIndex));
            }

            return null;
        }

        public IEnumerable<Square> GetAllUp()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.GetUp();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? GetDown()
        {
            var newRankIndex = Rank.Index - 1;
            if (Rank.IsValidIndex(newRankIndex))
            {
                return new Square(File, Rank.WithIndex(newRankIndex));
            }

            return null;
        }

        public IEnumerable<Square> GetAllDown()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.GetDown();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? GetLeft()
        {
            var newFileIndex = File.Index - 1;
            if (File.IsValidIndex(newFileIndex))
            {
                return new Square(File.WithIndex(newFileIndex), Rank);
            }

            return null;
        }

        public IEnumerable<Square> GetAllLeft()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.GetLeft();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? GetRight()
        {
            var newFileIndex = File.Index + 1;
            if (File.IsValidIndex(newFileIndex))
            {
                return new Square(File.WithIndex(newFileIndex), Rank);
            }

            return null;
        }

        public IEnumerable<Square> GetAllRight()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.GetRight();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? GetUpRight()
        {
            var newFileIndex = File.Index + 1;
            var newRankIndex = Rank.Index + 1;

            if (File.IsValidIndex(newFileIndex)
                && Rank.IsValidIndex(newRankIndex))
            {
                return new Square(File.WithIndex(newFileIndex), Rank.WithIndex(newRankIndex));
            }

            return null;
        }

        public IEnumerable<Square> GetAllUpRight()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.GetUpRight();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? GetUpLeft()
        {
            var newFileIndex = File.Index - 1;
            var newRankIndex = Rank.Index + 1;

            if (File.IsValidIndex(newFileIndex)
                && Rank.IsValidIndex(newRankIndex))
            {
                return new Square(File.WithIndex(newFileIndex), Rank.WithIndex(newRankIndex));
            }

            return null;
        }

        public IEnumerable<Square> GetAllUpLeft()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.GetUpLeft();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? GetDownLeft()
        {
            var newFileIndex = File.Index - 1;
            var newRankIndex = Rank.Index - 1;

            if (File.IsValidIndex(newFileIndex)
                && Rank.IsValidIndex(newRankIndex))
            {
                return new Square(File.WithIndex(newFileIndex), Rank.WithIndex(newRankIndex));
            }

            return null;
        }

        public IEnumerable<Square> GetAllDownLeft()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.GetDownLeft();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? GetDownRight()
        {
            var newFileIndex = File.Index + 1;
            var newRankIndex = Rank.Index - 1;

            if (File.IsValidIndex(newFileIndex)
                && Rank.IsValidIndex(newRankIndex))
            {
                return new Square(File.WithIndex(newFileIndex), Rank.WithIndex(newRankIndex));
            }

            return null;
        }

        public IEnumerable<Square> GetAllDownRight()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.GetDownRight();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public IEnumerable<Square> GetPathTo(Square targetSquare)
        {
            IEnumerable<Square>[] allRanges =
            {
                GetAllUp(),
                GetAllDown(),
                GetAllRight(),
                GetAllLeft(),
                GetAllUpRight(),
                GetAllUpLeft(),
                GetAllDownRight(),
                GetAllDownLeft()
            };

            foreach (var range in allRanges)
            {
                if (range.Contains(targetSquare))
                {
                    return range.TakeWhile(square => square.Equals(targetSquare));
                }
            }

            throw new InvalidOperationException("No valid path towards square!");
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return File;
            yield return Rank;
        }
    }
}