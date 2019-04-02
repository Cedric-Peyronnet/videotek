using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    class Personne
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; set; }
        private string Nom { get; set; }
        private string Prenom { get; set; }
        private Civilite Civilite { get; set; }
        private string Nationalite { get; set; }
        private DateTime DateNaissance { get; set; }
        private string Photo { get; set; }
    }
}
