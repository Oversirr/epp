using System.Collections.Generic;
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
            Genre rpg = new Genre {Name = "RPG"};
            PlatformType pc = new PlatformType(){Type = "PC"};
            PlatformType ps4 = new PlatformType(){Type = "Sony PlayStation 4"};
            PlatformType xBoxOne = new PlatformType(){Type = "XBox One"};
            Game d3 = new Game()
            {
                Description = "The Prime Evil rages within the Black Soulstone." +
                              " Before the artifact can be sealed away forever," +
                              " Malthael–Angel of Death–manifests in the mortal realms with a deadly new purpose:" +
                              " to steal the Black Soulstone and bend its infernal power to his will. ",
                Genres = new List<Genre>(new []{rpg,action}),
                Key = "d3",
                PlatformTypes = new List<PlatformType>(new [] { pc, ps4, xBoxOne }),
                Name = "Diablo 3"
            };
            dbContext.Genres.Add(races);
            dbContext.Genres.Add(strategy);
            dbContext.Genres.Add(action);
            dbContext.Genres.Add(new Genre {ParentGenre = strategy, Name = "RTS"});
            dbContext.Genres.Add(new Genre {Name = "TBS", ParentGenre = strategy});
            dbContext.Genres.Add(rpg);
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
            dbContext.PlatformTypes.Add(pc);
            dbContext.PlatformTypes.Add(ps4);
            dbContext.PlatformTypes.Add(xBoxOne);
            dbContext.PlatformTypes.AddRange(new []{pc,ps4,xBoxOne});
            dbContext.Games.Add(d3);
            dbContext.SaveChanges();
        }
    }
}