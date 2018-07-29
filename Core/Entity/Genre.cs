using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace GameStore.Core.Entity
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }
        public virtual Genre ParentGenre { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
