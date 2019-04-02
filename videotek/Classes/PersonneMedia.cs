using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    public class PersonneMedia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdPersonne { get; set; }
        [ForeignKey(nameof(IdPersonne))]
        public Personne Personne { get; set; }

        public int IdMedia { get; set; }
        [ForeignKey(nameof(IdMedia))]
        public Media Media { get; set; }

        public Fonction Fonction { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }
    }
}
