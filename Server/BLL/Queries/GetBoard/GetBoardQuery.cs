using MediatR;

namespace BLL.Queries.GetBoard
{
    public class GetBoardQuery : IRequest<GetBoardResponse>
    {
        public int GameId { get; init; }

        public GetBoardQuery(int gameId)
        {
            GameId = gameId;
        }
    }
}