using MediatR;

namespace BLL.Queries.GetBoard
{
    internal class GetBoardHandler : IRequestHandler<GetBoardQuery, GetBoardResponse>
    {
        public Task<GetBoardResponse> Handle(GetBoardQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}