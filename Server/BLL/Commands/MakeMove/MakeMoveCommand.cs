using MediatR;

namespace BLL.Commands.MakeMove
{
    public class MakeMoveCommand : IRequest<MakeMoveResponse>
    {
        public int GameId { get; init; }
        public string StartSquare { get; init; }
        public string TargetSquare { get; init; }

        public MakeMoveCommand(int gameId, string startSquare, string targetSquare)
        {
            GameId = gameId;
            StartSquare = startSquare;
            TargetSquare = targetSquare;
        }
    }
}