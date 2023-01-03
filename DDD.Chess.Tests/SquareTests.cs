using DDD.Chess.ValueObjects;

using File = DDD.Chess.ValueObjects.File;

namespace DDD.Chess.Tests
{
    internal class SquareTests
    {
        [Test]
        public void NavigateUp_WhenUpperSquareExists_ShouldReturnCorrectResult()
        {
            var square = new Square(File.A, Rank.ONE);
            var result = square.Up();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Rank, Is.EqualTo(Rank.TWO));
        }

        [Test]
        public void NavigateUp_WhenUpperSquareDoesntExist_ShouldReturnNull()
        {
            var square = new Square(File.A, Rank.EIGHT);
            var result = square.Up();

            Assert.That(result, Is.Null);
        }

        [Test]
        public void NavigateAllUp_ShouldReturnCorrectResult()
        {
            var square = new Square(File.A, Rank.ONE);
            var result = square.AllUp();

            var expected = new List<Square>
            {
                new Square(File.A, Rank.TWO),
                new Square(File.A, Rank.THREE),
                new Square(File.A, Rank.FOUR),
                new Square(File.A, Rank.FIVE),
                new Square(File.A, Rank.SIX),
                new Square(File.A, Rank.SEVEN),
                new Square(File.A, Rank.EIGHT)
            };

            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void NavigateDown_WhenItExists_ShouldReturnCorrectResult()
        {
            var square = new Square(File.A, Rank.EIGHT);
            var result = square.Down();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Rank, Is.EqualTo(Rank.SEVEN));
        }

        [Test]
        public void NavigateLeft_WhenItExists_ShouldReturnCorrectResult()
        {
            var square = new Square(File.H, Rank.ONE);
            var result = square.Left();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.File, Is.EqualTo(File.G));
        }

        [Test]
        public void NavigateRight_WhenItExists_ShouldReturnCorrectResult()
        {
            var square = new Square(File.A, Rank.ONE);
            var result = square.Right();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.File, Is.EqualTo(File.B));
        }

        [Test]
        public void NavigateUpLeft_WhenItExists_ShouldReturnCorrectResult()
        {
            var square = new Square(File.H, Rank.ONE);
            var result = square.UpLeft();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.File, Is.EqualTo(File.G));
            Assert.That(result.Rank, Is.EqualTo(Rank.TWO));
        }

        [Test]
        public void NavigateUpRight_WhenItExists_ShouldReturnCorrectResult()
        {
            var square = new Square(File.A, Rank.ONE);
            var result = square.UpRight();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.File, Is.EqualTo(File.B));
            Assert.That(result.Rank, Is.EqualTo(Rank.TWO));
        }

        [Test]
        public void NavigateDownLeft_WhenItExists_ShouldReturnCorrectResult()
        {
            var square = new Square(File.H, Rank.EIGHT);
            var result = square.DownLeft();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.File, Is.EqualTo(File.G));
            Assert.That(result.Rank, Is.EqualTo(Rank.SEVEN));
        }

        [Test]
        public void NavigateDownRight_WhenItExists_ShouldReturnCorrectResult()
        {
            var square = new Square(File.A, Rank.EIGHT);
            var result = square.DownRight();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.File, Is.EqualTo(File.B));
            Assert.That(result.Rank, Is.EqualTo(Rank.SEVEN));
        }
    }
}