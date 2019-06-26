using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
   public class EpisodeMedia
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdEpisode { get; set; }
        [ForeignKey(nameof(IdEpisode))]
        public Episode Episode { get; set; }

        public int IdMedia { get; set; }
        [ForeignKey(nameof(IdMedia))]
        public Media Media { get; set; }
    }
}
