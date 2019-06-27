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
        private MainViewModel mainViewModel;

        private string recherche ="";
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

        private bool filtreActif;
        public bool FiltreActif { get => filtreActif; set => SetProperty(ref filtreActif, value); }

        private bool filtreVu;
        public bool FiltreVu
        {
            get
            {
                return filtreVu;
            }
            set
            {
                if (SetProperty(ref filtreVu, value))
                {
                    filtreVu = value;
                    RechercheMedia();
                }
            }
        }

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
                    mainViewModel.MediaCourrant = value;
                    if(selectedItem != null && mainViewModel.MediaCourrant.Type.Equals(ETypeMedia.Serie))
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
                    mainViewModel.EpisodeCourrant = value;                    
                };
            }
        }

        #endregion 
        public MediaViewModel(MainViewModel mvm)
        {
            mainViewModel = mvm;
            _canExecute = true;
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
            List<Episode> episodes = context.Episodes.Where(e => e.IdMedia == id).ToList();
            foreach (Episode ep in episodes)
            {
                MaListEpisode.Remove(ep);
                context.Episodes.Remove(ep);
            }              
            context.SaveChanges();
        }

        private async void  RecuperationDesEpisodesDeSerie()
        {
            MaListEpisode.Clear();

            var context = await db.VideoTDbContext.GetCurrent();
            List<Episode> episodes = context.Episodes.Where(e => e.IdMedia == SelectedItem.Id).ToList();

            foreach (Episode episode in episodes)
                MaListEpisode.Add(episode);
        }

        private bool unBool;

        public bool UnBool { get => unBool; set => SetProperty(ref unBool, value); }

        private string texte = "bouton de test";

        public string Texte { get => texte; set => SetProperty(ref texte, value); }


        UtilsCommand command;
        public UtilsCommand Command
       
        {
            get
            {
               return command ?? (command = new UtilsCommand(() => MyAction(), _canExecute));
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

        private async void RechercheMedia()
        {
            var context = await db.VideoTDbContext.GetCurrent();
           if(FiltreActif)
            {
                if (mainViewModel.PageCourrante.Equals(mainViewModel.FM))
                {
                    MaListFilm.Clear();
                    List<Media> films = context.Medias.Where(m => m.Type == ETypeMedia.Film && m.Titre.Contains(Recherche) && m.Vu == FiltreVu).ToList();

                    foreach (Media film in films)
                        MaListFilm.Add(film);
                }
                else if (mainViewModel.PageCourrante.Equals(mainViewModel.SM))
                {
                    MaListEpisode.Clear();
                    MaListSerie.Clear();
                    recherche = Recherche;
                    
                    List<Media> series = context.Medias.Where(m => m.Type == ETypeMedia.Serie && m.Titre.Contains(Recherche) && m.Vu == FiltreVu).ToList();

                    foreach (Media serie in series)
                        MaListSerie.Add(serie);
                }
            }
            else
            {
                if (mainViewModel.PageCourrante.Equals(mainViewModel.FM))
                {
                    MaListFilm.Clear();
                    List<Media> films = context.Medias.Where(m => m.Type == ETypeMedia.Film).ToList();

                    foreach (Media film in films)
                        MaListFilm.Add(film);
                }
                else if (mainViewModel.PageCourrante.Equals(mainViewModel.SM))
                {
                    MaListEpisode.Clear();
                    MaListSerie.Clear();
                    recherche = Recherche;
                    List<Media> series = context.Medias.Where(m => m.Type == ETypeMedia.Serie && m.Titre.Contains(Recherche)).ToList();

                    foreach (Media serie in series)
                        MaListSerie.Add(serie);
                }
            }
                        
        }

      
        private async void RecuperationGenre()
        {
            var context = await db.VideoTDbContext.GetCurrent();
            List<Genre> genres = context.Genres.ToList();


            foreach (Genre genre in genres)
                ListeGenre.Add(genre);

            if (genres.Count> 0)
            {
                FiltreGenre = genres[0];
            }
        }

        private bool _canExecute;
        public void MyAction()
        {
            Texte += "PATATEUH";
        }
    } 
}
