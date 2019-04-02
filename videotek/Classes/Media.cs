using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    class Media
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; set; }
        private TimeSpan Duree { get; set; }
        private DateTime DateSortie { get; set; }
        private string Titre { get; set; }
        private string Description { get; set; }
        private bool Vu { get; set; }
        private int Note { get; set; }
        private string Commentaire { get; set; }
        private TypeMedia Type { get; set; }
        private int AgeMinimum { get; set; }
        private bool SupportPhysique { get; set; }
        private bool supportNumerique { get; set; }
        private string Image { get; set; }
        private Langue LangueVO { get; set; }
        private Langue LangueMedia { get; set; }
        private Langue SousTitre { get; set; }
    }
}
