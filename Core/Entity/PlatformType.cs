using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Core.Entity
{
    public class PlatformType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
