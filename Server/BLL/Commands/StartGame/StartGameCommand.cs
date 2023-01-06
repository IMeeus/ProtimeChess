using MediatR;

namespace BLL.Commands.StartGame
{
    public class StartGameCommand : IRequest<StartGameResponse>
    {
        public int GameId { get; init; }

        public StartGameCommand(int gameId)
        {
            GameId = gameId;
        }
    }
}