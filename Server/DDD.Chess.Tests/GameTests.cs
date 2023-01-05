using DDD.Chess.Commands;
using DDD.Chess.Exceptions;
using DDD.Chess.Identifiers;
using DDD.Chess.ValueObjects;
using File = DDD.Chess.ValueObjects.File;

namespace DDD.Chess.Tests
{
    public class GameTests
    {
        [Test]
        public void StartGame_WhenGameHasAlreadyStarted_ShouldThrowError()
        {
            var gameId = new GameId(1);
            var game = new Game(gameId);
            var startGameCommand = new StartGame();

            game.Start(startGameCommand);

            var exception = Assert.Throws<ChessException>(() =>
                game.Start(startGameCommand)
            );
            Assert.That(exception.Message, Is.EqualTo(ChessException.GameNotInInitialState.Message));
        }

        [Test]
        public void MakeMove_WhenGameHasNotStarted_ShouldThrowError()
        {
            var gameId = new GameId(1);
            var game = new Game(gameId);

            var startSquare = new Square(File.A, Rank.ONE);
            var endSquare = new Square(File.A, Rank.TWO);
            var makeMoveCommand = new MakeMove(new Move(startSquare, endSquare));

            var exception = Assert.Throws<ChessException>(() =>
                game.MakeMove(makeMoveCommand)
            );
            Assert.That(exception.Message, Is.EqualTo(ChessException.GameNotInRunningState.Message));
        }

        [Test]
        public void MakeMove_FromA7ToA6_ShouldThrowInvalidTurn()
        {
            var gameId = new GameId(1);
            var game = new Game(gameId);

            var startGameCommand = new StartGame();
            game.Start(startGameCommand);

            var startSquare = new Square(File.A, Rank.SEVEN);
            var endSquare = new Square(File.A, Rank.SIX);
            var makeMoveCommand = new MakeMove(new Move(startSquare, endSquare));

            var exception = Assert.Throws<ChessException>(() =>
                game.MakeMove(makeMoveCommand)
            );
            Assert.That(exception.Message, Is.EqualTo(ChessException.InvalidTurn.Message));
        }

        [Test]
        public void MakeMove_FromA5ToA4_ShouldThrowNoPiece()
        {
            var gameId = new GameId(1);
            var game = new Game(gameId);

            var startGameCommand = new StartGame();
            game.Start(startGameCommand);

            var startSquare = new Square(File.A, Rank.FIVE);
            var endSquare = new Square(File.A, Rank.FOUR);
            var makeMoveCommand = new MakeMove(new Move(startSquare, endSquare));

            var exception = Assert.Throws<ChessException>(() =>
                game.MakeMove(makeMoveCommand)
            );
            Assert.That(exception.Message, Is.EqualTo(ChessException.NoPieceOnStartSquare.Message));
        }
    }
}