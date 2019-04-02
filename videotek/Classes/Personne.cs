using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    public class Personne
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Civilite Civilite { get; set; }
        public string Nationalite { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Photo { get; set; }
    }
}
