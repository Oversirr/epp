﻿using System.Collections.Generic;

namespace GameStore.Core.Entity
{
    public class Game
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<PlatformType> PlatformTypes { get; set; }
    }
}
