using BLL.Domain.Factories;
using BLL.Infrastructure.Interfaces;
using DDD.Chess.Aggregates;
using DDD.Chess.Identifiers;
using DDD.Chess.ValueObjects;
using MediatR;
using Newtonsoft.Json;
using File = DDD.Chess.ValueObjects.File;
using MakeChessMove = DDD.Chess.Commands.MakeMove;

namespace BLL.Commands.MakeMove
{
    internal class MakeMoveHandler : IRequestHandler<MakeMoveCommand, MakeMoveResponse>
    {
        private readonly IGameEventRepository _gameEventRepository;
        private readonly GameFactory _gameFactory;

        public MakeMoveHandler(IGameEventRepository gameEventRepository, GameFactory gameFactory)
        {
            _gameEventRepository = gameEventRepository;
            _gameFactory = gameFactory;
        }

        public async Task<MakeMoveResponse> Handle(MakeMoveCommand request, CancellationToken cancellationToken)
        {
            GameId gameId = new(request.GameId);

            Game game = await _gameFactory.ConstructLatest(gameId);

            File startFile = File.WithValue(request.StartSquare[0].ToString());
            Rank startRank = Rank.WithIndex(int.Parse(request.StartSquare[1].ToString()));
            Square startSquare = new(startFile, startRank);

            File targetFile = File.WithValue(request.TargetSquare[0].ToString());
            Rank targetRank = Rank.WithIndex(int.Parse(request.TargetSquare[1].ToString()));
            Square targetSquare = new(targetFile, targetRank);

            Move move = new(startSquare, targetSquare);
            MakeChessMove command = new(move);

            game.MakeMove(command);

            foreach (var @event in game.Events)
            {
                var eventType = @event.GetType().Name;
                var eventData = JsonConvert.SerializeObject(@event);

                await _gameEventRepository.PushEvent(gameId.Value, eventType, eventData);
            }

            return new MakeMoveResponse(true);
        }
    }
}