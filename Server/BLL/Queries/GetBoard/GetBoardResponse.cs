using BLL.ViewModels;

namespace BLL.Queries.GetBoard
{
    public class GetBoardResponse
    {
        public BoardVM Board { get; init; }

        public GetBoardResponse(BoardVM board)
        {
            Board = board;
        }
    }
}