using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    internal class Square : ValueObject
    {
        public File File { get; init; }
        public Rank Rank { get; init; }

        public Square(File file, Rank rank)
        {
            File = file;
            Rank = rank;
        }

        public Square? Up()
        {
            var newRankIndex = Rank.Index + 1;
            if (Rank.IsValidIndex(newRankIndex))
            {
                return new Square(File, Rank.WithIndex(newRankIndex));
            }

            return null;
        }

        // Bestaat hier niets generiek voor?
        // Generate collection door recursief method te callen tot die null returned...
        public IEnumerable<Square> AllUp()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.Up();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? Down()
        {
            var newRankIndex = Rank.Index - 1;
            if (Rank.IsValidIndex(newRankIndex))
            {
                return new Square(File, Rank.WithIndex(newRankIndex));
            }

            return null;
        }

        public IEnumerable<Square> AllDown()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.Down();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? Left()
        {
            var newFileIndex = File.Index - 1;
            if (File.IsValidIndex(newFileIndex))
            {
                return new Square(File.WithIndex(newFileIndex), Rank);
            }

            return null;
        }

        public IEnumerable<Square> AllLeft()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.Left();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? Right()
        {
            var newFileIndex = File.Index + 1;
            if (File.IsValidIndex(newFileIndex))
            {
                return new Square(File.WithIndex(newFileIndex), Rank);
            }

            return null;
        }

        public IEnumerable<Square> AllRight()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.Right();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? UpRight()
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

        public IEnumerable<Square> AllUpRight()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.UpRight();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? UpLeft()
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

        public IEnumerable<Square> AllUpLeft()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.UpLeft();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? DownLeft()
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

        public IEnumerable<Square> AllDownLeft()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.DownLeft();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        public Square? DownRight()
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

        public IEnumerable<Square> AllDownRight()
        {
            Square? currentSquare = this;
            while (true)
            {
                currentSquare = currentSquare.DownRight();
                if (currentSquare is null) break;
                yield return currentSquare;
            }
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return File;
            yield return Rank;
        }
    }
}