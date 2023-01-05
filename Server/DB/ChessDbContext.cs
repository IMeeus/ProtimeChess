using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class ChessDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
    }
}