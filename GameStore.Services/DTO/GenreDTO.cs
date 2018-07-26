using System.Collections.Generic;

namespace GameStore.Services.DTO
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }
        public GenreDTO ParentGenre { get; set; }
        public ICollection<GameDTO> Games { get; set; }
    }
}
