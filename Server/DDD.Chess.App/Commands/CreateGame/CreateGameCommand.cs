using MediatR;

namespace DDD.Chess.App.Commands.CreateGame
{
    public class CreateGameCommand : IRequest<CreateGameResponse>
    {
    }
}