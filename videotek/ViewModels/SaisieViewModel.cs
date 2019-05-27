using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using videotek.Classes;
using videotek.Utils;

namespace videotek.ViewModels
{
    public class SaisieViewModel : UtilsBinding
    {
        private string titre;
        public string Titre { get => titre; set => SetProperty(ref titre, value); }

        private string commentaire;
        public string Commentaire { get => commentaire; set => SetProperty(ref commentaire, value); }

        private string description;
        public string Description { get => description; set => SetProperty(ref description, value); }

        private int ageMini;
        public int AgeMini { get => ageMini; set => SetProperty(ref ageMini, value); }

        private int note;
        public int Note { get => note; set => SetProperty(ref note, value); }

        private bool vu = false;
        public bool Vu { get => vu; set => SetProperty(ref vu, value); }

        private bool supportPhysique = false;
        public bool SupportPhysique { get => supportPhysique; set => SetProperty(ref supportPhysique, value); }

        private bool supportNumerique = false;
        public bool SupportNumerique { get => supportNumerique; set => SetProperty(ref supportNumerique, value); }

        private DateTime annee;
        public DateTime Annee { get => annee; set => SetProperty(ref annee, value); }

        private TimeSpan duree;
        public TimeSpan Duree { get => duree; set => SetProperty(ref duree, value); }

        private Langue langueVo;
        public Langue LangueVo { get => langueVo; set => SetProperty(ref langueVo, value); }

        private Langue langueSousTitre;
        public Langue LangueSousTitre { get => langueSousTitre; set => SetProperty(ref langueSousTitre, value); }

        private Langue langueMedia;
        public Langue LangueMedia { get => langueMedia; set => SetProperty(ref langueMedia, value); }

        public SaisieViewModel()
        {
            _canExecute = true;
        }

        private bool _canExecute;

        UtilsCommand ajoutSaisie;
        public UtilsCommand AjoutSaisie
        {
            get
            {
                return ajoutSaisie ?? (ajoutSaisie = new UtilsCommand(() => MyAction(), _canExecute));
            }
        }
 
        public void MyAction()
        {
            EnregistrerAsync();
        }

        private async void EnregistrerAsync()
        {
            var context = await db.VideoTDbContext.GetCurrent();

            context.Add(new Media()
            {
                Titre = Titre,
                Commentaire = Commentaire,
                Description = Description,
                DateSortie = Annee,
                Duree = Duree,
                AgeMinimum = AgeMini,
                Note = Note,
                LangueMedia = LangueMedia,
                LangueVO = LangueVo,
                SousTitre = LangueSousTitre,
                Vu = Vu,
                SupportNumerique = SupportNumerique,
                SupportPhysique = SupportPhysique
            }
            );
            await context.SaveChangesAsync();
        }
    }
}
