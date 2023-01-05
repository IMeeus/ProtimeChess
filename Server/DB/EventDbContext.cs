using Events.Db.Models.Aggregates;
using Events.Db.Models.Events;
using Microsoft.EntityFrameworkCore;

namespace Events.Db
{
    internal class EventDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<GameEvent> GameEvents { get; set; } = null!;
    }
}