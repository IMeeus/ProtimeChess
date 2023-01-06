using DDD.Core;

namespace DDD.Chess.ValueObjects
{
    public class Rank : ValueObject
    {
        public int Index { get; init; }

        public static Rank ONE => new(0);
        public static Rank TWO => new(1);
        public static Rank THREE => new(2);
        public static Rank FOUR => new(3);
        public static Rank FIVE => new(4);
        public static Rank SIX => new(5);
        public static Rank SEVEN => new(6);
        public static Rank EIGHT => new(7);

        public static Rank WithIndex(int index)
        {
            return Values.Single(x => x.Index == index);
        }

        public static IEnumerable<Rank> Values
        {
            get
            {
                var ranks = new List<Rank> { ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT };
                return ranks.AsEnumerable();
            }
        }

        private Rank(int index)
        {
            Index = index;
        }

        public static bool IsValidIndex(int rankIndex) => rankIndex >= 0 && rankIndex < Values.Count();

        public static Rank operator +(Rank source, int number)
        {
            return WithIndex(source.Index + number);
        }

        public static Rank operator -(Rank source, int number)
        {
            return WithIndex(source.Index - number);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Index;
        }

        public override string ToString()
        {
            return Index.ToString();
        }
    }
}