using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        private GenreMedia GenreMediaCourant { get; set; }
        private GenreMedia SousGenreMediaCourant { get; set; }
        private bool estUnAjout { get; set; }

        private Media monMedia;
        public Media MonMedia { get => monMedia; set => SetProperty(ref monMedia, value); }

        private Genre genre;
        public Genre Genre { get => genre; set => SetProperty(ref genre, value); }

        private Genre sousGenre;
        public Genre SousGenre { get => sousGenre; set => SetProperty(ref sousGenre, value); }

        public MediaViewModel MediaViewModel { get; set; }

        private int heures;
        public int Heures { get => heures; set => SetProperty(ref heures, value); }

        private int minutes;
        public int Minutes { get => minutes; set => SetProperty(ref minutes, value); }


        #endregion

        #region constructeur
        public SaisieMediaViewModel(Action close, MediaViewModel mediaViewModel, Media media)
        {
            RecuperationGenre();

            CloseAction = close;
            MediaViewModel = mediaViewModel;

            MonMedia = media;
            RecuperationGenreMedia();

            Heures = MonMedia.Duree.Hours;
            Minutes = MonMedia.Duree.Minutes;

            estUnAjout = false;
        }

        public SaisieMediaViewModel(Action close, MediaViewModel mediaViewModel, ETypeMedia eTypeMedia)
        {
            RecuperationGenre();
            CloseAction = close;
            MediaViewModel = mediaViewModel;

            estUnAjout = true;

            MonMedia = new Media();

            MonMedia.Type = eTypeMedia;
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
            MonMedia.Duree = ts;

            if (estUnAjout)
            {
                context.Add(MonMedia);
                if (MonMedia.Type.Equals(ETypeMedia.Film))
                {
                    MediaViewModel.MaListFilm.Add(MonMedia);
                }
                else
                {
                    MediaViewModel.MaListSerie.Add(MonMedia);
                }

            }
            //Cas d'une modification
            else
            {
                if (GenreMediaCourant != null)
                {
                    context.Remove(GenreMediaCourant);
                }
                if (SousGenreMediaCourant != null)
                {
                    context.Remove(SousGenreMediaCourant);
                }
                await context.SaveChangesAsync();

                if (MonMedia.Type.Equals(ETypeMedia.Film))
                {
                    MediaViewModel.MaListFilm.Remove(MonMedia);
                    MediaViewModel.MaListFilm.Add(MonMedia);
                }
                else
                {
                    MediaViewModel.MaListSerie.Remove(MonMedia);
                    MediaViewModel.MaListSerie.Add(MonMedia);
                }

            }

            await context.SaveChangesAsync();

            if (Genre != null || SousGenre != null)
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
                if (null != SousGenre && SousGenre != Genre)
                {

                    GenreMedia sousGenreMedia = new GenreMedia()
                    {
                        IdGenre = SousGenre.Id,
                        IdMedia = MonMedia.Id
                    };
                    context.Add(sousGenreMedia);
                }

            }
            await context.SaveChangesAsync();
            
            MessageBox.Show("Enregistré");

            CloseAction();
        }
        #endregion

        #region recuperation
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

            List<GenreMedia> ListGenresMedia = context.GenreMedias.Where(me => me.IdMedia == MonMedia.Id).ToList();

            if (ListGenresMedia.Count > 0 && ListGenresMedia[0] != null)
            {
                GenreMediaCourant = ListGenresMedia[0];
                Genre = context.Genres.Where(gm => gm.Id == ListGenresMedia[0].IdGenre).First();
            }
            if (ListGenresMedia.Count > 1 && ListGenresMedia[1] != null)
            {
                SousGenreMediaCourant = ListGenresMedia[1];
                SousGenre = context.Genres.Where(gm => gm.Id == ListGenresMedia[1].IdGenre).First();
            }
        }
        #endregion
    }
}