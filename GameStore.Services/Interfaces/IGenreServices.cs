using System.Collections.Generic;
using GameStore.Services.DTO;

namespace GameStore.Services.Interfaces
{
    public interface IGenreServices
    {
        void CreateNewGenre(GenreDTO genre);
        void EditGenre(GenreDTO genre);
        void DeleteGenre(GenreDTO genre);
        IEnumerable<GenreDTO> GetAllGenres();
    }
}
