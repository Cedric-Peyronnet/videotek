using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    class GenreMedia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int IdGenre { get; set; }
        private int IdMedia { get; set; }
    }
}
