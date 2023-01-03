using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    internal class File : ValueObject
    {
        public int Index { get; init; }

        public static File A => new(0);
        public static File B => new(1);
        public static File C => new(2);
        public static File D => new(3);
        public static File E => new(4);
        public static File F => new(5);
        public static File G => new(6);
        public static File H => new(7);

        public static File WithIndex(int index)
        {
            return Values.Single(x => x.Index == index);
        }

        public static IEnumerable<File> Values
        {
            get
            {
                var files = new List<File> { A, B, C, D, E, F, G, H };
                return files.AsEnumerable();
            }
        }

        private File(int index)
        {
            Index = index;
        }

        public static bool IsValidIndex(int fileIndex) => fileIndex >= 0 && fileIndex < Values.Count();

        public static File operator +(File source, int number)
        {
            return WithIndex(source.Index + number);
        }

        public static File operator -(File source, int number)
        {
            return WithIndex(source.Index - number);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Index;
        }
    }
}