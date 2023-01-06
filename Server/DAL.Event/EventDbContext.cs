using Microsoft.EntityFrameworkCore;
using Model.Aggregates;
using Model.Events;

namespace Events.Db
{
    internal class EventDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<GameEvent> GameEvents { get; set; } = null!;
    }
}