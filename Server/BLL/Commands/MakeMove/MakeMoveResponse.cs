namespace BLL.Commands.MakeMove
{
    public class MakeMoveResponse
    {
        public bool Success { get; init; }

        public MakeMoveResponse(bool success)
        {
            Success = success;
        }
    }
}