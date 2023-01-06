using BLL.ViewModels;
using DDD.Chess.ValueObjects;

namespace BLL.Domain.Dozers
{
    internal class BoardDozer
    {
        public Task<BoardVM> Doze(Board board)
        {
            var boardState = board.State;

            foreach (var kv in boardState)
            {
                var square = kv.Key;
                var piece = kv.Value;
            }

            return Task.FromResult(new BoardVM());
        }
    }
}