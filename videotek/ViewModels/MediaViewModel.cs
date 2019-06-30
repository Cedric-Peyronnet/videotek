using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using videotek.Classes;
using videotek.Utils;

namespace videotek.ViewModels
{
    public class MediaViewModel : UtilsBinding
    {
        #region propriété
        public MainViewModel MainViewModel;

        private ETypeMedia TypeMediaCourant { get; set; }

        private string recherche = "";
        public string Recherche { get => recherche; set => SetProperty(ref recherche, value); }

        private ObservableCollection<Media> maListFilm = new ObservableCollection<Media>();
        public ObservableCollection<Media> MaListFilm { get => maListFilm; set => SetProperty(ref maListFilm, value); }

        private ObservableCollection<Media> maListSerie = new ObservableCollection<Media>();
        public ObservableCollection<Media> MaListSerie { get => maListSerie; set => SetProperty(ref maListSerie, value); }

        private ObservableCollection<Episode> maListEpisode = new ObservableCollection<Episode>();
        public ObservableCollection<Episode> MaListEpisode { get => maListEpisode; set => SetProperty(ref maListEpisode, value); }

        private ObservableCollection<Genre> listeGenre = new ObservableCollection<Genre>();
        public ObservableCollection<Genre> ListeGenre { get => listeGenre; set => SetProperty(ref listeGenre, value); }

        private Genre filtreGenre;
        public Genre FiltreGenre { get => filtreGenre; set => SetProperty(ref filtreGenre, value); }


        private int filtreSaison;
        public int FiltreSaison { get => filtreSaison; set => SetProperty(ref filtreSaison, value); }


        private bool filtreActif;
        public bool FiltreActif
        {
            get
            {
                return filtreActif;
            }
            set
            {
                if (SetProperty(ref filtreActif, value))
                {

                    filtreActif = value;
                }
            }
        }

        private bool filtreVu;
        public bool FiltreVu { get => filtreVu; set => SetProperty(ref filtreVu, value); }

        private Media selectedItem;
        public Media SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                if (SetProperty(ref selectedItem, value))
                {
                    selectedItem = value;
                    MainViewModel.MediaCourrant = value;

                    if (selectedItem != null && MainViewModel.MediaCourrant.Type.Equals(ETypeMedia.Serie))
                    {
                        RecuperationDesEpisodesDeSerie();
                    }
                };

            }
        }

        private Episode selectedItemEpisode;
        public Episode SelectedItemEpisode
        {
            get
            {
                return selectedItemEpisode;
            }

            set
            {
                if (SetProperty(ref selectedItemEpisode, value))
                {
                    selectedItemEpisode = value;
                    MainViewModel.EpisodeCourrant = value;
                };
            }
        }

        #endregion 

        public MediaViewModel(MainViewModel mvm)
        {
            MainViewModel = mvm;

            InitialisationValeursConsultationAsync();
            RecuperationGenre();
        }


        private async void InitialisationValeursConsultationAsync()
        {
            var context = await db.VideoTDbContext.GetCurrent();
            List<Media> films = context.Medias.Where(m => m.Type == ETypeMedia.Film).ToList();

            foreach (Media film in films)
                MaListFilm.Add(film);

            List<Media> series = context.Medias.Where(m => m.Type == ETypeMedia.Serie).ToList();

            foreach (Media serie in series)
                MaListSerie.Add(serie);
        }

        public async void SupprimerLesEpisodes(int id)
        {
            var context = await db.VideoTDbContext.GetCurrent();
            foreach (EpisodeMedia ep in context.EpisodesMedia.Where(e => e.IdMedia == id).ToList())
            {
                context.EpisodesMedia.Remove(ep);
            }

            foreach (Episode ep in context.Episodes.Where(e => e.IdMedia == id).ToList())
            {
                MaListEpisode.Remove(ep);
                context.Episodes.Remove(ep);
            }
            context.SaveChanges();
        }

        private async void RecuperationDesEpisodesDeSerie()
        {
            MaListEpisode.Clear();
            var context = await db.VideoTDbContext.GetCurrent();
            List<Episode> listEpisode = new List<Episode>();

            if (FiltreActif)
            {
                var query = from e in context.Episodes
                            where e.NumSaison == FiltreSaison
                            where e.IdMedia == MainViewModel.MediaCourrant.Id
                            select e;
                if (filtreSaison > 0)
                {
                    query.Where(e => e.NumSaison == FiltreSaison);
                }
                foreach (Episode episode in query.ToList())
                    MaListEpisode.Add(episode);
            }
            else
            {
                foreach (Episode episode in context.Episodes.Where(e => e.IdMedia == SelectedItem.Id).ToList())
                    MaListEpisode.Add(episode);
            }

        }

        UtilsCommand rechercheCommand;
        public UtilsCommand RechercheCommand

        {
            get
            {
                return rechercheCommand ?? (rechercheCommand = new UtilsCommand(() => RechercheMedia(), _canExecute));
            }
        }

        public async void RechercheMedia()
        {
            List<Media> Medias = new List<Media>();

            var context = await db.VideoTDbContext.GetCurrent();
            TypeMediaCourant = MainViewModel.TypeMediaCourant;

            if (FiltreActif)
            {
                var query = from m in context.Medias
                            from mg in context.GenreMedias
                            where m.Id == mg.IdMedia
                            where m.Vu == FiltreVu
                            where m.Titre.Contains(Recherche)
                            where m.Type == TypeMediaCourant
                            where mg.Genre.Id == FiltreGenre.Id
                            select m;
                if (true)
                {
                    query.Where(m => m.Titre.Contains(Recherche));
                }
                Medias = query.ToList();
            }
            else
            {
                Medias = context.Medias.Where(m => m.Type == MainViewModel.TypeMediaCourant && m.Titre.Contains(Recherche)).ToList();
            }

            if (MainViewModel.TypeMediaCourant.Equals(ETypeMedia.Film))
            {
                MaListFilm.Clear();
                foreach (Media film in Medias)
                    MaListFilm.Add(film);


                if (MaListFilm.Count > 0)
                {
                    SelectedItem = MaListSerie[0];
                }
            }
            else
            {
                MaListEpisode.Clear();
                MaListSerie.Clear();
                foreach (Media serie in Medias)
                    MaListSerie.Add(serie);

                if (MaListSerie.Count > 0)
                {
                    SelectedItem = MaListSerie[0];
                }
            }



        }

        private async void RecuperationGenre()
        {
            var context = await db.VideoTDbContext.GetCurrent();
            List<Genre> genres = context.Genres.ToList();
            foreach (Genre genre in genres)
                ListeGenre.Add(genre);

            if (genres.Count > 0)
            {
                FiltreGenre = genres[0];
            }
        }



        UtilsCommand commandActiverFiltre;
        public UtilsCommand CommandActiverFiltre
        {
            get
            {
                return commandActiverFiltre ?? (commandActiverFiltre = new UtilsCommand(() => ActiverFiltre(), _canExecute));
            }
        }

        UtilsCommand commandDesactiverFiltre;
        public UtilsCommand CommandDesactiverFiltre
        {
            get
            {
                return commandDesactiverFiltre ?? (commandDesactiverFiltre = new UtilsCommand(() => DesactiverFiltre(), _canExecute));
            }
        }

        private void ActiverFiltre()
        {
            FiltreActif = true;
            RechercheMedia();
        }

        private void DesactiverFiltre()
        {
            FiltreActif = false;
            RechercheMedia();
        }

        bool _canExecute = true;

    }
}
