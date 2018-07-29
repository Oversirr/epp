using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Services.Interfaces;

namespace GameStore.Services.DTO
{
    public class GameEditDTO : IGameDTO
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<PlatformDTO> PlatformTypes { get; set; }
    }
}
