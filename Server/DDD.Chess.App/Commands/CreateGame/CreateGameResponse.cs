namespace DDD.Chess.App.Commands.CreateGame
{
    public class CreateGameResponse
    {
        public int GameId { get; init; }

        public CreateGameResponse(int gameId)
        {
            GameId = gameId;
        }
    }
}