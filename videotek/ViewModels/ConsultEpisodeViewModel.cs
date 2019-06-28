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
