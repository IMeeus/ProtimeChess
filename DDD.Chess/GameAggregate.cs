using DDD.Chess.Commands;
using DDD.Chess.DomainEvents;
using DDD.Chess.Exceptions;
using DDD.Chess.Factories;
using DDD.Chess.Identifiers;
using DDD.Chess.ValueObjects;
using DDD.Core;

namespace DDD.Chess
{
    internal class GameAggregate : AggregateRoot<GameId>
    {
        private readonly GameId _id;

        private GameState _state;
        private Color _turnColor;
        private Board _board;

        public GameAggregate(GameId id) : base(id)
        {
            _id = id;
            _state = GameState.INITIAL;
            _turnColor = Color.WHITE;
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

        public void MakeMove(MakeMove command)
        {
            if (_state != GameState.RUNNING)
            {
                throw ChessException.GameNotInRunningState;
            }

            var pieceAtStart = _board.State[command.Move.StartSquare];

            if (pieceAtStart is null)
            {
                throw ChessException.NoPieceOnStartSquare;
            }

            if (pieceAtStart.Color != _turnColor)
            {
                throw ChessException.InvalidTurn;
            }

            var pieceAtTarget = _board.State[command.Move.TargetSquare];
            bool isCapturing = pieceAtTarget is not null;

            // Rules:
            // - within range of piece
            // - can't pass through pieces, unless knight
            // - can't attack friendly pieces
            // - move can't result in check

            // Special:
            // - En Passant
            // - Castling

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