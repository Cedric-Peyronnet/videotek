using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using videotek.Classes;
using videotek.Utils;

namespace videotek.ViewModels
{
    public class SaisieMediaViewModel : UtilsBinding
    {
        public Action CloseAction { get; set; }

        private Media monMedia;
        public Media MonMedia { get => monMedia; set => SetProperty(ref monMedia, value); }

        public FilmViewModel FilmViewModel { get; set; }

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

        private ELangue langueVo;
        public ELangue LangueVo { get => langueVo; set => SetProperty(ref langueVo, value); }

        private ELangue langueSousTitre;
        public ELangue LangueSousTitre { get => langueSousTitre; set => SetProperty(ref langueSousTitre, value); }

        private ELangue langueMedia;
        public ELangue LangueMedia { get => langueMedia; set => SetProperty(ref langueMedia, value); }

        public SaisieMediaViewModel(Action close, FilmViewModel filmViewModel, Media media)
        {
            CloseAction = close;
            FilmViewModel = filmViewModel;

            Titre = media.Titre;
            Commentaire = media.Commentaire;
            Description = media.Description;
            annee = media.DateSortie;
            Duree = media.Duree;
            AgeMini = media.AgeMinimum;
            Note = media.Note;
            LangueMedia = LangueMedia;
            LangueVo = media.LangueVO;
            LangueSousTitre = media.SousTitre;
            Vu = media.Vu;
            SupportNumerique = media.SupportNumerique;
            SupportPhysique = media.SupportPhysique;
        }

        public SaisieMediaViewModel(Action close, FilmViewModel filmViewModel)
        {
            CloseAction = close;
            FilmViewModel = filmViewModel;
        }

       

        private bool _canExecute = true;


        UtilsCommand annuler;
        public UtilsCommand Annuler
        {
            get
            {
                return annuler ?? (annuler = new UtilsCommand(() => AnnulerAction(), _canExecute));
            }
        }

        UtilsCommand ajoutSaisie;
        public UtilsCommand AjoutSaisie
        {
            get
            {
                return ajoutSaisie ?? (ajoutSaisie = new UtilsCommand(() => EnregistrerAction(), _canExecute));
            }
        }
 
        public void EnregistrerAction()
        {
            EnregistrerAsync();
        }

        public void AnnulerAction()
        {
            CloseAction();
        }

        private async void EnregistrerAsync()
        {
            var context = await db.VideoTDbContext.GetCurrent();
            Media m = new Media()
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
            };
            context.Add(m);
            await context.SaveChangesAsync();
            
            MessageBox.Show("Enregistré");
            FilmViewModel.MaListFilm.Add(m);
            CloseAction();
           
        }
    }
}
