namespace BLL.Infrastructure.Models
{
    public class GameEvent
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Order { get; set; }
        public string EventType { get; set; } = null!;
        public string EventData { get; set; } = null!;
    }
}