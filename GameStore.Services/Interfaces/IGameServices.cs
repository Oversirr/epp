using System.Collections.Generic;
using GameStore.Services.DTO;

namespace GameStore.Services.Interfaces
{
    public interface IGameServices
    {
        void CreateNewGame (GameCreateDTO game);
        void EditGame(GameEditDTO game);
        void DeleteGame(GameEditDTO game);
        GameShowDTO GetGameByKey (string key);
        IEnumerable<GameShowDTO> GetGames();
        IEnumerable<GameShowDTO> GetGamesByGenre (GenreDTO genre);
        IEnumerable<GameShowDTO> GetGamesByPlatformType (PlatformDTO platform);
    }
}
