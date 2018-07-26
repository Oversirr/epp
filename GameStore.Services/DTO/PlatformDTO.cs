﻿using System.Collections.Generic;

namespace GameStore.Services.DTO
{
    public class PlatformDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<GameDTO> Games { get; set; }
    }
}
