using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    public class File : ValueObject
    {
        public string Value { get; init; }
        public int Index { get; init; }

        public static File A => new(0, "A");
        public static File B => new(1, "B");
        public static File C => new(2, "C");
        public static File D => new(3, "D");
        public static File E => new(4, "E");
        public static File F => new(5, "F");
        public static File G => new(6, "G");
        public static File H => new(7, "H");

        public static File WithIndex(int index)
        {
            return Values.Single(x => x.Index == index);
        }

        public static File WithValue(string value)
        {
            return Values.Single(x => x.Value == value);
        }

        public static IEnumerable<File> Values
        {
            get
            {
                var files = new List<File> { A, B, C, D, E, F, G, H };
                return files.AsEnumerable();
            }
        }

        private File(int index, string value)
        {
            Index = index;
            Value = value;
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

        public override string ToString()
        {
            return Value;
        }
    }
}