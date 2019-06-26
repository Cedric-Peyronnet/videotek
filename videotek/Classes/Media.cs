using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public ETypeMedia Type { get; set; }
        public int AgeMinimum { get; set; }
        public bool SupportPhysique { get; set; }
        public bool SupportNumerique { get; set; }
        public string Image { get; set; }
        public ELangue LangueVO { get; set; }
        public ELangue LangueMedia { get; set; }
        public ELangue SousTitre { get; set; }

        [InverseProperty(nameof(GenreMedia.Media))]
        public List<GenreMedia> Genre { get; set; }

        [InverseProperty(nameof(EpisodeMedia.Media))]
        public List<EpisodeMedia> Episode { get; set; }

        [InverseProperty(nameof(PersonneMedia.Media))]
        public List<PersonneMedia> Personne { get; set; }
    }
}
