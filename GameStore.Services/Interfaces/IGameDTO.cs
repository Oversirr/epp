using System.Collections.Generic;
using GameStore.Services.DTO;

namespace GameStore.Services.Interfaces
{
    public interface IGameDTO
    {
        ICollection<GenreDTO> Genres { get; set; }
        ICollection<PlatformDTO> PlatformTypes { get; set; }
    }
}