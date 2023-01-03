using DDD.Chess.ValueObjects;
using DDD.Chess.ValueObjects.Pieces;

using File = DDD.Chess.ValueObjects.File;

namespace DDD.Chess.Tests
{
    internal class PieceTests
    {
        [Test]
        public void GetRangeFromBishop_ShouldBeCorrect()
        {
            Bishop bishop = new(Color.WHITE);
            Square fromSquare = new(File.B, Rank.ONE);

            var expected = new List<Square>
            {
                new(File.A, Rank.TWO),
                new(File.C, Rank.TWO),
                new(File.D, Rank.THREE),
                new(File.E, Rank.FOUR),
                new(File.F, Rank.FIVE),
                new(File.G, Rank.SIX),
                new(File.H, Rank.SEVEN)
            };

            var result = bishop.GetMoveRange(fromSquare);

            Assert.That(result, Is.EquivalentTo(expected));
        }

        //[Test]
        //public void GetRangeFromKing_ShouldBeCorrect()
        //{
        //}

        //[Test]
        //public void GetRangeFromKnight_ShouldBeCorrect()
        //{
        //}

        //[Test]
        //public void GetRangeFromPawn_ShouldBeCorrect()
        //{
        //}

        //[Test]
        //public void GetRangeFromQueen_ShouldBeCorrect()
        //{
        //}

        //[Test]
        //public void GetRangeFromRook_ShouldBeCorrect()
        //{
        //}

        //[Test]
        //public void GetAttackRangeFromPawn_ShouldBeCorrect()
        //{
        //}
    }
}