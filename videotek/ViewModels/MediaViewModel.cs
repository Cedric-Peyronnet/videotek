using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videotek.Utils;

namespace videotek.ViewModels
{
    class MediaViewModel : UtilsBinding
    {
        /**
      Titre = titre.Text,
             AgeMinimum = int.Parse(ageMini.Text),
             Commentaire = commentaire.Text,
             DateSortie = DateTime.Parse(date.Text),
             Description = description.Text,
             Duree = TimeSpan.Parse(dure.Text),
             LangueVO = (Langue)Enum.Parse(typeof(Langue), langueVO.Text),
             SousTitre = (Langue)Enum.Parse(typeof(Langue), sousTitres.Text),
             LangueMedia = (Langue)Enum.Parse(typeof(Langue), langue.Text),
 */
        private string titre;
        public string Titre { get => titre; set => SetProperty(ref titre, value); }

        private string commentaire;
        public string Commentaire { get => commentaire; set => SetProperty(ref commentaire, value); }

        private string description;
        public string Description { get => description; set => SetProperty(ref description, value); }

    }
}
