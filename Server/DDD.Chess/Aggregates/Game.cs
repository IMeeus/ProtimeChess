using DDD.Chess.Commands;
using DDD.Chess.DomainEvents;
using DDD.Chess.Exceptions;
using DDD.Chess.Factories;
using DDD.Chess.Identifiers;
using DDD.Chess.ValueObjects;
using DDD.Core;

namespace DDD.Chess.Aggregates
{
    public class Game : AggregateRoot<GameId>
    {
        private readonly List<Move> _moveHistory;

        public GameState State { get; private set; }
        public Color CurrentPlayerColor { get; private set; }
        public Board Board { get; private set; }

        public Game(GameId id) : base(id)
        {
            Initialize();
        }

        public Game(GameId id, IEnumerable<DomainEvent> events) : base(id, events)
        {
            Initialize();
        }

        private void Initialize()
        {
            State = GameState.INITIAL;
            CurrentPlayerColor = Color.WHITE;
            Board = BoardFactory.NewBoard();
        }

        public void Start()
        {
            if (State != GameState.INITIAL)
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
            if (State != GameState.RUNNING)
            {
                throw ChessException.GameNotInRunningState;
            }

            var startSquare = command.Move.StartSquare;
            var pieceAtStart = Board.GetPieceOn(startSquare);

            if (pieceAtStart is null)
            {
                throw ChessException.NoPieceOnStartSquare;
            }

            if (pieceAtStart.Color != CurrentPlayerColor)
            {
                throw ChessException.InvalidTurn;
            }

            var newBoard = pieceAtStart.Move(Board, command.Move, _moveHistory);

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
            State = GameState.RUNNING;
        }

        private void Handle(MoveMade @event)
        {
            throw new NotImplementedException();
        }
    }
}