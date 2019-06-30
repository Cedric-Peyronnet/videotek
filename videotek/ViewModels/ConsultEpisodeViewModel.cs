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
        }

        private bool episodeSuivant;
        public bool EpisodeSuivant { get => episodeSuivant; set => SetProperty(ref episodeSuivant, value); }

        private bool episodePrecedent;
        public bool EpisodePrecedent { get => episodePrecedent; set => SetProperty(ref episodePrecedent, value); }

        private Episode monEpisode;
        public Episode MonEpisode { get => monEpisode; set => SetProperty(ref monEpisode, value); }

        private TimeSpan duree;
        public TimeSpan Duree { get => duree; set => SetProperty(ref duree, value); }

    }
}
