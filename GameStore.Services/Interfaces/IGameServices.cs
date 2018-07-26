using System.Collections.Generic;
using GameStore.Services.DTO;

namespace GameStore.Services.Interfaces
{
    public interface IGameServices
    {
        void CreateNewGame (GameDTO game);
        void EditGame (GameDTO game);
        void DeleteGame (GameDTO game);
        GameDTO GetGameByKey (string key);
        IEnumerable<GameDTO> GetGames();
        IEnumerable<GameDTO> GetGamesByGenre (GenreDTO genre);
        IEnumerable<GameDTO> GetGamesByPlatformType (PlatformDTO platform);
    }
}
