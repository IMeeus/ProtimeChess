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

            if (newBoard.IsKingInCheck(CurrentPlayerColor, _moveHistory))
            {
                throw ChessException.CantMakeMoveResultingInCheck;
            }

            RaiseEvent(new MoveMade(command.Move));

            if (newBoard.IsKingInCheckMate(CurrentPlayerColor.GetOpposite(), _moveHistory))
            {
                RaiseEvent(new GameEnded());
            }
        }

        protected override void When(DomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case GameStarted gameStarted: Handle(gameStarted); break;
                case MoveMade moveMade: Handle(moveMade); break;
                case GameEnded gameEnded: Handle(gameEnded); break;
                default: throw new NotImplementedException();
            }
        }

        private void Handle(GameStarted @event)
        {
            State = GameState.RUNNING;
        }

        private void Handle(MoveMade @event)
        {
            Move move = @event.Move;
            Piece pieceAtStart = Board.GetPieceOn(move.StartSquare)!;

            Board = pieceAtStart.Move(Board, move, _moveHistory);
        }

        private void Handle(GameEnded @event)
        {
            State = GameState.ENDED;
        }
    }
}