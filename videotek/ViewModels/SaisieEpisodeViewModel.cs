using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private Episode Episode { get; set; }

        private int numSaison;
        public int NumSaison { get => numSaison; set => SetProperty(ref numSaison, value); }

        private int numEpisode;
        public int NumEpisode { get => numEpisode; set => SetProperty(ref numEpisode, value); }

        private string titre;
        public string Titre { get => titre; set => SetProperty(ref titre, value); }

        private string description;
        public string Description { get => description; set => SetProperty(ref description, value); }

        private DateTime dateDiffusion;
        public DateTime DateDiffusion { get => dateDiffusion; set => SetProperty(ref dateDiffusion, value); }

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
            Episode = episode;
          
            Titre = episode.Titre;
            NumSaison = episode.NumSaison;
            NumEpisode = episode.NumEpisode;
            DateDiffusion = episode.DateDiffusion;
            Heures = episode.Duree.Hours;
            Minutes = episode.Duree.Minutes;
            Description = episode.Description;
        }

        public SaisieEpisodeViewModel(Action close, MediaViewModel mediaViewModel)
        {  
            CloseAction = close;
            MediaViewModel = mediaViewModel;
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

            if (Episode == null)
            {
                Episode e = new Episode()
                {
                    Titre = Titre,
                    Description = Description,
                    DateDiffusion = DateDiffusion,
                    Duree = ts,
                    IdMedia = MediaViewModel.SelectedItem.Id,
                    NumSaison = NumSaison,
                    NumEpisode = NumEpisode,
                };
                context.Episodes.Add(e);
                Episode = e;
                await context.SaveChangesAsync();
                context.EpisodesMedia.Add(new EpisodeMedia { IdMedia = MediaViewModel.SelectedItem.Id, IdEpisode = Episode.Id });
                MediaViewModel.MaListEpisode.Add(e);
            }
            //Cas d'une modification
            else
            {
                var entity = context.Episodes.Find(Episode.Id);
               
                if (entity == null)
                {
                    return;
                }
                MediaViewModel.MaListEpisode.Remove(Episode);

                Episode.Titre = Titre;            
                Episode.Description = Description;
                Episode.Duree = ts;
                Episode.NumSaison = NumSaison;
                Episode.NumEpisode = NumEpisode;
                Episode.DateDiffusion = DateDiffusion;
                context.Entry(entity).CurrentValues.SetValues(Episode);
                MediaViewModel.MaListEpisode.Add(Episode);
                context.EpisodesMedia.Remove(context.EpisodesMedia.Where(em => em.IdEpisode == Episode.Id).First());
                await context.SaveChangesAsync();
                context.EpisodesMedia.Add(new EpisodeMedia { IdMedia = MediaViewModel.SelectedItem.Id, IdEpisode = Episode.Id });
            }

            await context.SaveChangesAsync();
            MessageBox.Show("Enregistré");
            CloseAction();

        }
        #endregion

    }
}
