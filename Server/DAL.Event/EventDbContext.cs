using Microsoft.EntityFrameworkCore;
using Model.Aggregates;
using Model.Events;

namespace Events.Db
{
    internal class EventDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<GameEvent> GameEvents { get; set; } = null!;

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameEvent>()
                .HasOne<Game>()
                .WithMany();
        }
    }
}