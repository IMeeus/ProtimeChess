namespace DDD.Chess.Exceptions
{
    internal class ChessException : Exception
    {
        public static ChessException GameNotInRunningState
            => new("Game is not in running state!");

        public static ChessException GameNotInInitialState
            => new("Game is not in initial state!");

        public static ChessException InvalidTurn
            => new("Invalid turn!");

        public static ChessException NoPieceOnStartSquare
            => new("No piece on square!");

        public static ChessException InvalidMove
            => new("Invalid move!");

        public static ChessException CanNotCaptureFriendlyPieces
            => new("Can not capture piece of same color!");

        public static ChessException SquareNotInRangeOfPiece
            => new("Square not in range of piece!");

        public static ChessException CantMoveThroughPieces
            => new("Can't move through pieces!");

        private ChessException(string message) : base(message)
        {
        }
    }
}