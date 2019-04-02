using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    class PersonneMedia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; set; }

        private int IdPersonne { get; set; }
        

        private int IdMedia { get; set; }


        private Fonction Fonction { get; set; }
        private string Role { get; set; }
        private string Photo { get; set; }
    }
}
