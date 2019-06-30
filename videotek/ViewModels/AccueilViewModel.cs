using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videotek.Classes;
using videotek.Utils;

namespace videotek.ViewModels
{
    public class AccueilViewModel : UtilsBinding
    {
        #region propriete
        #region film
        private int nombreFilmAVoir;
        public int NombreFilmAVoir { get => nombreFilmAVoir; set => SetProperty(ref nombreFilmAVoir, value); }

        private int nombreFilmEnregistre;
        public int NombreFilmEnregistre { get => nombreFilmEnregistre; set => SetProperty(ref nombreFilmEnregistre, value); }

        private int noteMoyenneFilm;
        public int NoteMoyenneFilm { get => noteMoyenneFilm; set => SetProperty(ref noteMoyenneFilm, value); }

        #endregion
        #region Serie
        private int nombreSerieEnregistree;
        public int NombreSerieEnregistree { get => nombreSerieEnregistree; set => SetProperty(ref nombreSerieEnregistree, value); }

        private int nombreSerieAVoir;
        public int NombreSerieAVoir { get => nombreSerieAVoir; set => SetProperty(ref nombreSerieAVoir, value); }

        private int noteMoyenneSerie;
        public int NoteMoyenneSerie { get => noteMoyenneSerie; set => SetProperty(ref noteMoyenneSerie, value); }

        private string dernierEpisodeAjoute;
        public string DernierEpisodeAjoute { get => dernierEpisodeAjoute; set => SetProperty(ref dernierEpisodeAjoute, value); }
        #endregion

        private MainViewModel MainViewModel;

        private ObservableCollection<KeyValuePair<string, int>> grapListSerie = new ObservableCollection<KeyValuePair<string, int>>();
        public ObservableCollection<KeyValuePair<string, int>> GrapListSerie { get => grapListSerie; set => SetProperty(ref grapListSerie, value); }

        private ObservableCollection<KeyValuePair<string, int>> grapListFilm = new ObservableCollection<KeyValuePair<string, int>>();
        public ObservableCollection<KeyValuePair<string, int>> GrapListFilm { get => grapListFilm; set => SetProperty(ref grapListFilm, value); }


        #endregion

        #region constructeur
        public AccueilViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            GenererDonnee();
        }

        #endregion

        public async void GenererDonnee()
        {
            GrapListSerie.Clear();
            GrapListFilm.Clear();

            var context = await db.VideoTDbContext.GetCurrent();
            List<Media> listeMedia = context.Medias.ToList();

            int nbFilmEnregistre = 0;
            int nbFilmAVoir = 0;
            int pointTotauxFilm = 0;
            int nbFilmVu = 0;

            int nbSerieEnregistree = 0;
            int nbSerieAVoir = 0;
            int nbSerieVu = 0;
            int pointTotauxSerie = 0;

            foreach (Media media in listeMedia)
            {
                if (media.Type.Equals(ETypeMedia.Serie))

                {
                    nbSerieEnregistree++;
                    if (!media.Vu)
                    {
                        nbSerieAVoir++;
                    }
                    else
                    {
                        nbSerieVu++;
                        pointTotauxSerie = pointTotauxFilm + media.Note;
                    }
                }
                else
                {
                    nbFilmEnregistre++;
                    if (!media.Vu)
                    {
                        nbFilmAVoir++;
                    }

                    else
                    {
                        nbFilmVu++;
                        pointTotauxFilm = pointTotauxFilm + media.Note;
                    }
                }
            }


            if (nbSerieVu != 0)
            {
                NoteMoyenneSerie = pointTotauxSerie / nbSerieVu;
            }

            NombreSerieAVoir = nbSerieAVoir;
            NombreSerieEnregistree = nbSerieEnregistree;

            if (nbFilmVu != 0)
            {
                NoteMoyenneFilm = pointTotauxFilm / nbFilmVu;
            }

            NombreFilmAVoir = nbFilmAVoir;
            NombreFilmEnregistre = nbFilmEnregistre;

            var ListGenresMedia = context.GenreMedias.GroupBy(m => m.IdGenre).ToList();

            List<GenreMedia> genreMedia = context.GenreMedias.ToList();

            List<Media> countListeMediaGenre = listeMedia;
            List<int> countSerie = new List<int>();
            List<int> countFilm = new List<int>();

            List<string> libelleGenre = new List<string>();

            for (int i = 0; i < ListGenresMedia.Count; i++)
            {
                var querySerie =
                    from me in context.Medias
                    from mg in context.GenreMedias
                    where me.Id == mg.IdMedia
                    where me.Type == ETypeMedia.Serie
                    where mg.Genre.Id == genreMedia[i].IdGenre
                    select me;

                countSerie.Add(querySerie.Count());

                var queryFilm =
                    from me in context.Medias
                    from mg in context.GenreMedias
                    where me.Id == mg.IdMedia
                    where me.Type == ETypeMedia.Film
                    where mg.Genre.Id == genreMedia[i].IdGenre
                    select me;
                countFilm.Add(queryFilm.Count());

                libelleGenre.Add(context.Genres.Where(g => g.Id == ListGenresMedia[i].Key).First().Libelle);
            }

            for (int i = 0; i < libelleGenre.Count; i++)
            {
                GrapListSerie.Add(new KeyValuePair<string, int>(libelleGenre[i] + " " + countSerie[i], countSerie[i]));
            }

            for (int i = 0; i < libelleGenre.Count; i++)
            {
                GrapListFilm.Add(new KeyValuePair<string, int>(libelleGenre[i] + " " + countFilm[i], countFilm[i]));
            }
        }
    }
}
