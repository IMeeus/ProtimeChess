using DDD.Chess.Commands;
using DDD.Chess.DomainEvents;
using DDD.Chess.Exceptions;
using DDD.Chess.Factories;
using DDD.Chess.Identifiers;
using DDD.Chess.ValueObjects;
using DDD.Core;

namespace DDD.Chess
{
    public class GameAggregate : AggregateRoot<GameId>
    {
        private GameState _state;
        private Color _currentPlayerColor;
        private Board _board;

        public GameAggregate(GameId id) : base(id)
        {
            _state = GameState.INITIAL;
            _currentPlayerColor = Color.WHITE;
            _board = BoardFactory.NewBoard();
        }

        public void Start(StartGame command)
        {
            if (_state != GameState.INITIAL)
            {
                throw ChessException.GameNotInInitialState;
            }

            RaiseEvent(new GameStarted());
        }

        // Rules:
        // - within range of piece
        // - can't pass through pieces, unless knight
        // - can't attack friendly pieces
        // - move can't result in check

        // Special:
        // - En Passant
        // - Castling
        public void MakeMove(MakeMove command)
        {
            if (_state != GameState.RUNNING)
            {
                throw ChessException.GameNotInRunningState;
            }

            var startSquare = command.Move.StartSquare;
            var pieceAtStart = _board.GetPieceOnSquare(startSquare);

            if (pieceAtStart is null)
            {
                throw ChessException.NoPieceOnStartSquare;
            }

            if (pieceAtStart.Color != _currentPlayerColor)
            {
                throw ChessException.InvalidTurn;
            }

            var targetSquare = command.Move.TargetSquare;
            var pieceAtTarget = _board.GetPieceOnSquare(targetSquare);

            if (pieceAtTarget is null) // not capturing
            {
                var moveRange = pieceAtStart.GetMoveRange(startSquare);
                if (!moveRange.Contains(targetSquare))
                {
                    throw ChessException.SquareNotInRangeOfPiece;
                }
            }
            else // capturing
            {
                if (pieceAtTarget.Color == _currentPlayerColor)
                {
                    throw ChessException.CanNotCaptureFriendlyPieces;
                }

                var attackRange = pieceAtStart.GetAttackRange(startSquare);
                if (!attackRange.Contains(targetSquare))
                {
                    throw ChessException.SquareNotInRangeOfPiece;
                }
            }

            if (!pieceAtStart.CanJump)
            {
                var squaresTowardsTarget = startSquare.GetPathTo(targetSquare).ToList();
                squaresTowardsTarget.Remove(targetSquare);

                var anyPiecesBetweenStartAndTarget = squaresTowardsTarget.Any(square =>
                {
                    var pieceOnSquare = _board.GetPieceOnSquare(square);
                    return pieceOnSquare is not null;
                });

                if (anyPiecesBetweenStartAndTarget)
                {
                    throw ChessException.CantMoveThroughPieces;
                }
            }

            RaiseEvent(new MoveMade());
        }

        protected override void When(DomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case GameStarted gameStarted: Handle(gameStarted); break;
                case MoveMade moveMade: Handle(moveMade); break;
                default: throw new InvalidEventException();
            }
        }

        private void Handle(GameStarted @event)
        {
            _state = GameState.RUNNING;
        }

        private void Handle(MoveMade @event)
        {
        }
    }
}