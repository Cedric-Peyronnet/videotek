using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        #region propriété 
        public Action CloseAction { get; set; }

        private ObservableCollection<Genre> listeGenre = new ObservableCollection<Genre>();

        public ObservableCollection<Genre> ListeGenre { get => listeGenre; set => SetProperty(ref listeGenre, value); }

        private Media monMedia;
        public Media MonMedia { get => monMedia; set => SetProperty(ref monMedia, value); }

        private Genre genre;
        public Genre Genre { get => genre; set => SetProperty(ref genre, value); }

        private Genre sousGenre;
        public Genre SousGenre { get => sousGenre; set => SetProperty(ref sousGenre, value); }

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

        private int heures;
        public int Heures { get => heures; set => SetProperty(ref heures, value); }

        private int minutes;
        public int Minutes { get => minutes; set => SetProperty(ref minutes, value); }

        private TimeSpan duree;
        public TimeSpan Duree { get => duree; set => SetProperty(ref duree, value); }

        private ELangue langueVo;
        public ELangue LangueVo { get => langueVo; set => SetProperty(ref langueVo, value); }

        private ELangue langueSousTitre;
        public ELangue LangueSousTitre { get => langueSousTitre; set => SetProperty(ref langueSousTitre, value); }

        private ELangue langueMedia;
        public ELangue LangueMedia { get => langueMedia; set => SetProperty(ref langueMedia, value); }

        private ETypeMedia type;
        public ETypeMedia Type { get => type; set => SetProperty(ref type, value); }
        #endregion

        #region constructeur
        public SaisieMediaViewModel(Action close, FilmViewModel filmViewModel, Media media)
        {
            RecuperationGenre();

            CloseAction = close;
            FilmViewModel = filmViewModel;
            MonMedia = media;

            RecuperationGenreMedia();

            Titre = media.Titre;
            Commentaire = media.Commentaire;
            Description = media.Description;
            annee = media.DateSortie;
            Heures = media.Duree.Hours;
            Minutes = media.Duree.Minutes;
            AgeMini = media.AgeMinimum;
            Note = media.Note;
            LangueMedia = media.LangueMedia;
            LangueVo = media.LangueVO;
            LangueSousTitre = media.SousTitre;
            Vu = media.Vu;
            Type = media.Type;
            SupportNumerique = media.SupportNumerique;
            SupportPhysique = media.SupportPhysique;
           
           
        }

        public SaisieMediaViewModel(Action close, FilmViewModel filmViewModel)
        {
            RecuperationGenre();

            CloseAction = close;
            FilmViewModel = filmViewModel;
        }
        #endregion

        #region command & action
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
        #endregion

        #region enregistrement

        private async void EnregistrerAsync()
        {
            var context = await db.VideoTDbContext.GetCurrent();
            TimeSpan ts = new TimeSpan(Heures, minutes, 0);

            if (MonMedia == null)
            {
                Media m = new Media()
                {
                    Titre = Titre,
                    Commentaire = Commentaire,
                    Description = Description,
                    DateSortie = Annee,
                    Duree = ts,
                    AgeMinimum = AgeMini,
                    Note = Note,
                    LangueMedia = LangueMedia,
                    LangueVO = LangueVo,
                    SousTitre = LangueSousTitre,
                    Vu = Vu,
                    Type = Type,
                    SupportNumerique = SupportNumerique,
                    SupportPhysique = SupportPhysique
                };
                context.Add(m);
                FilmViewModel.MaListFilm.Add(m);
                MonMedia = m;
            }
            //Cas d'une modification
            else
            {
                var entity = context.Medias.Find(MonMedia.Id);
                if (entity == null)
                {
                    return;
                }
                MonMedia.Titre = Titre;
                MonMedia.Commentaire = Commentaire;
                MonMedia.Description = Description;
                MonMedia.DateSortie = Annee;
                MonMedia.Duree = ts;
                MonMedia.AgeMinimum = AgeMini;
                MonMedia.Note = Note;
                MonMedia.LangueMedia = LangueMedia;
                MonMedia.LangueVO = LangueVo;
                MonMedia.SousTitre = LangueSousTitre;
                MonMedia.Vu = Vu;
                MonMedia.SupportNumerique = SupportNumerique;
                MonMedia.SupportPhysique = SupportPhysique;
                MonMedia.Type = Type;
                context.Entry(entity).CurrentValues.SetValues(MonMedia);
            }
            
            await context.SaveChangesAsync();

           if(Genre != null || SousGenre != null)
            {
                //Enregistrement du genre et du media
                if (Genre != null)
                {
                    GenreMedia genreMedia = new GenreMedia()
                    {
                        IdGenre = Genre.Id,
                        IdMedia = MonMedia.Id

                    };
                    context.Add(genreMedia);
                }


                if (null != SousGenre)
                {
                    GenreMedia sousGenreMedia = new GenreMedia()
                    {
                        IdGenre = SousGenre.Id,
                        IdMedia = MonMedia.Id
                    };
                    context.Add(sousGenreMedia);
                }
                await context.SaveChangesAsync();
            }
           

            MessageBox.Show("Enregistré");        
            CloseAction();
           
        }
        #endregion

        #region
        private async void RecuperationGenre()
        {
            var context = await db.VideoTDbContext.GetCurrent();
            List<Genre> genres = context.Genres.ToList();

            foreach (Genre genre in genres)
                ListeGenre.Add(genre);
        }

        
        private async void RecuperationGenreMedia()
        {
            var context = await db.VideoTDbContext.GetCurrent();

            List<GenreMedia> ListGenresMedia = context.GenreMedias.Where(me => me.IdMedia  == MonMedia.Id).ToList();

            if(ListGenresMedia.Count > 0 && ListGenresMedia[0] != null  )
            {
                Genre = context.Genres.Where(gm => gm.Id == ListGenresMedia[0].IdGenre).First();
            }
            if (ListGenresMedia.Count > 1 && ListGenresMedia[1] != null)
            {
                SousGenre = context.Genres.Where(gm => gm.Id == ListGenresMedia[1].IdGenre).First();
            }

            

            
        }

        #endregion
    }
}
