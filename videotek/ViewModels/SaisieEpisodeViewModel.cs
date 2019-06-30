using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using videotek.Classes;
using videotek.Utils;

namespace videotek.ViewModels
{
    public class SaisieEpisodeViewModel : UtilsBinding
    {
        #region propriété 
        public Action CloseAction { get; set; }

        private MediaViewModel MediaViewModel { get; set; }

        private bool estUnAjout { get; set; }

        private Episode monEpisode;
        public Episode MonEpisode { get => monEpisode; set => SetProperty(ref monEpisode, value); }

        private int heures;
        public int Heures { get => heures; set => SetProperty(ref heures, value); }

        private int minutes;
        public int Minutes { get => minutes; set => SetProperty(ref minutes, value); }

        private TimeSpan duree;
        public TimeSpan Duree { get => duree; set => SetProperty(ref duree, value); }


        #endregion

        #region constructeur
        public SaisieEpisodeViewModel(Action close, MediaViewModel mediaViewModel, Episode episode)
        {
            CloseAction = close;
            MediaViewModel = mediaViewModel;
            MonEpisode = episode;

            estUnAjout = false;
        }

        public SaisieEpisodeViewModel(Action close, MediaViewModel mediaViewModel)
        {
            CloseAction = close;
            MediaViewModel = mediaViewModel;

            MonEpisode = new Episode() { };

            MonEpisode.DateDiffusion = new DateTime(2019, 01, 01);
            estUnAjout = true;
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

            MonEpisode.Duree = ts;
            if (estUnAjout)
            {
                context.Episodes.Add(MonEpisode);
                MonEpisode.IdMedia = MediaViewModel.SelectedItem.Id;
                context.SaveChanges();

                context.EpisodesMedia.Add(new EpisodeMedia { IdMedia = MediaViewModel.SelectedItem.Id, IdEpisode = MonEpisode.Id });
                MediaViewModel.MaListEpisode.Add(MonEpisode);
            }
            else
            {
                MediaViewModel.MaListEpisode.Remove(MonEpisode);
                MediaViewModel.MaListEpisode.Add(MonEpisode);
            }


            await context.SaveChangesAsync();

            
            CloseAction();

        }
        #endregion

    }
}