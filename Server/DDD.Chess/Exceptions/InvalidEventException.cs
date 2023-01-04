namespace DDD.Chess.Exceptions
{
    internal class InvalidEventException : Exception
    {
        private static readonly string _message = "Event doesn't exist!";

        public InvalidEventException() : base(_message)
        {
        }
    }
}