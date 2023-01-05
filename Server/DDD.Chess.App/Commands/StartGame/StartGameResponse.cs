namespace DDD.Chess.App.Commands.StartGame
{
    public class StartGameResponse
    {
        public bool Success { get; init; }

        public StartGameResponse(bool success)
        {
            Success = success;
        }
    }
}