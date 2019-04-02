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
        private int id { get; set; }
        private TimeSpan duree { get; set; }
        private DateTime dateSortie { get; set; }
        private string titre { get; set; }
        private string description { get; set; }
        private bool vu { get; set; }
        private int note { get; set; }
        private string commentaire { get; set; }
        private TypeMedia type { get; set; }
        private int ageMinimum { get; set; }
        private bool supportPhysique { get; set; }
        private bool supportNumerique { get; set; }
        private string image { get; set; }
        private Langue langueVO { get; set; }
        private Langue langueMedia { get; set; }
        private Langue sousTitre { get; set; }
    }
}
