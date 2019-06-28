using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videotek.Classes;
using videotek.Utils;

namespace videotek.ViewModels
{
    class ConsultEpisodeViewModel : UtilsBinding
    {

        public ConsultEpisodeViewModel(Episode episode, int idMedia)
        {
            monEpisode = episode;
            // l'id de media permettra d'aller sur l'épisode suivant
            //if il y a épisode suivant ou précedent on activera ou désactivera les buttons 
        }

        private List<int> listeEpisodeSaison;

        private bool episodeSuivant;
        public bool EpisodeSuivant { get => episodeSuivant; set => SetProperty(ref episodeSuivant, value); }

        private bool episodePrecedent;
        public bool EpisodePrecedent { get => episodePrecedent; set => SetProperty(ref episodePrecedent, value); }

        private Episode monEpisode;
        public Episode MonEpisode { get => monEpisode; set => SetProperty(ref monEpisode, value); }

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

        UtilsCommand commandEpisodeSuivant;
        public UtilsCommand CommandEpisodeSuivant
        {
            get
            {
                return commandEpisodeSuivant ?? (commandEpisodeSuivant = new UtilsCommand(() => MEpisodeSuivant(), episodeSuivant));
            }
        }

        private void MEpisodeSuivant()
        {

        }

        UtilsCommand commandEpisodePrecedent;
        public UtilsCommand CommandEpisodePrecedent
        {
            get
            {
                return commandEpisodeSuivant ?? (commandEpisodeSuivant = new UtilsCommand(() => MEpisodePrecedent(), episodePrecedent));
            }
        }

        private void MEpisodePrecedent()
        {

        }

    }
}
