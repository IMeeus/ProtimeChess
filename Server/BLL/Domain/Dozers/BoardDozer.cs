using BLL.ViewModels;
using DDD.Chess.ValueObjects;

namespace BLL.Domain.Dozers
{
    internal class BoardDozer
    {
        public BoardVM Doze(Board board)
        {
            Dictionary<Square, Piece?> boardState = board.CopyState();
            Dictionary<string, string?> vmBoardState = new();

            foreach (var kv in boardState)
            {
                Square square = kv.Key;
                Piece? piece = kv.Value;

                vmBoardState.Add($"{square.File}{square.Rank}", piece?.ToString());
            }

            return new BoardVM
            {
                State = vmBoardState
            };
        }
    }
}