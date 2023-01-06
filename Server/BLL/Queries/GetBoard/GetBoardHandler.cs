using BLL.Domain.Dozers;
using BLL.Domain.Factories;
using DDD.Chess.Identifiers;
using MediatR;

namespace BLL.Queries.GetBoard
{
    internal class GetBoardHandler : IRequestHandler<GetBoardQuery, GetBoardResponse>
    {
        private readonly GameFactory _gameFactory;
        private readonly BoardDozer _boardDozer;

        public GetBoardHandler(GameFactory gameFactory, BoardDozer boardDozer)
        {
            _gameFactory = gameFactory;
            _boardDozer = boardDozer;
        }

        public async Task<GetBoardResponse> Handle(GetBoardQuery request, CancellationToken cancellationToken)
        {
            var gameId = new GameId(request.GameId);
            var game = await _gameFactory.ConstructLatest(gameId);
            var boardVM = _boardDozer.Doze(game.Board);

            return new GetBoardResponse(boardVM);
        }
    }
}