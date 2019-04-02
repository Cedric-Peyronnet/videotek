using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    class Episode
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; set; }
        private int IdMedia { get; set; }
        private int NumSaison { get; set; }
        private int NumEpisode { get; set; }
        private TimeSpan Duree { get; set; }
        private string Titre { get; set; }
        private string Description { get; set; }
        private DateTime DateDiffusion { get; set; }
    }
}
