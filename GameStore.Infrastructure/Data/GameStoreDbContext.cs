using System.Data.Entity;
using GameStore.Core.Entity;

namespace GameStore.Infrastructure.Data
{
    public class GameStoreDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }

        public GameStoreDbContext():base("name = GameStore")
        {
            Database.SetInitializer<GameStoreDbContext>(new GameStoreInitializer());
        }
    }
}
