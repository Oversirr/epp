using System.Data.Entity;
using GameStore.Core.Entity;

namespace GameStore.Infrastructure.Data
{
    public class GameStoreInitializer : DropCreateDatabaseIfModelChanges<GameStoreDbContext>
    {
        protected override void Seed(GameStoreDbContext dbContext)
        {
            Genre strategy = new Genre{Name = "Strategy"};
            Genre races = new Genre {Name = "Races" };
            Genre action = new Genre {Name = "Action"};
            dbContext.Genres.Add(races);
            dbContext.Genres.Add(strategy);
            dbContext.Genres.Add(action);
            dbContext.Genres.Add(new Genre {ParentGenre = strategy, Name = "RTS"});
            dbContext.Genres.Add(new Genre {Name = "TBS", ParentGenre = strategy});
            dbContext.Genres.Add(new Genre {Name = "RPG"});
            dbContext.Genres.Add(new Genre {Name = "Sports"});
            dbContext.Genres.Add(new Genre { ParentGenre = races, Name = "Rally" });
            dbContext.Genres.Add(new Genre { Name = "Arcade", ParentGenre = races });
            dbContext.Genres.Add(new Genre { ParentGenre = races, Name = "Formula" });
            dbContext.Genres.Add(new Genre { Name = "Off-road", ParentGenre = races });
            dbContext.Genres.Add(new Genre { Name = "FPS", ParentGenre = action });
            dbContext.Genres.Add(new Genre { Name = "TPS", ParentGenre = action });
            dbContext.Genres.Add(new Genre { Name = "Misc.", ParentGenre = action });
            dbContext.Genres.Add(new Genre { Name = "Adventure" });
            dbContext.Genres.Add(new Genre { Name = "Puzzle & Skill" });
            dbContext.Genres.Add(new Genre { Name = "Misc." });
            dbContext.SaveChanges();
        }
    }
}