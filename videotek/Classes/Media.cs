using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    public class Media
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TimeSpan Duree { get; set; }
        public DateTime DateSortie { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public bool Vu { get; set; }
        public int Note { get; set; }
        public string Commentaire { get; set; }
        public TypeMedia Type { get; set; }
        public int AgeMinimum { get; set; }
        public bool SupportPhysique { get; set; }
        public bool SupportNumerique { get; set; }
        public string Image { get; set; }
        public Langue LangueVO { get; set; }
        public Langue LangueMedia { get; set; }
        public Langue SousTitre { get; set; }
    }
}
