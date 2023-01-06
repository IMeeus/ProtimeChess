namespace Model.Events
{
    public class GameEvent
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Order { get; set; }
        public string EventType { get; set; }
        public string EventData { get; set; }
    }
}