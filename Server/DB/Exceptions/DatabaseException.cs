namespace Events.Db.Exceptions
{
    internal class DatabaseException : Exception
    {
        public static DatabaseException AggregateNotFound
            => new("Aggregate not found!");

        public DatabaseException(string message) : base(message)
        {
        }
    }
}