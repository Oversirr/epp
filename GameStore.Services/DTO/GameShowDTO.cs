using System.Collections.Generic;
using GameStore.Services.Interfaces;

namespace GameStore.Services.DTO
{
    public class GameShowDTO : IGameDTO
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<PlatformDTO> PlatformTypes { get; set; }
    }
}
