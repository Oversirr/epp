using System.Collections.Generic;
using GameStore.Services.DTO;

namespace GameStore.Services.Interfaces
{
    public interface IPlatformServices
    {
        void CreateNewPlatformType(PlatformDTO platform);
        void EditPlatformType(PlatformDTO platform);
        void DeletePlatformType(PlatformDTO platform);
        IEnumerable<PlatformDTO> GetAllPlatformTypes();
    }
}
