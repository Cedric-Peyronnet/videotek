using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videotek.Classes;
using videotek.Frames.Common;
using videotek.Utils;

namespace videotek.ViewModels
{
    class ConsultationViewModel : UtilsBinding
    {
        public ConsultationViewModel(Media media)
        {
            MonMedia = media;
            RecuperationGenreMedia();
        }

        private Media monMedia;
        public Media MonMedia { get => monMedia; set => SetProperty(ref monMedia, value); }

        private string titre;
        public string Titre { get => MonMedia.Titre; set => SetProperty(ref titre, value); }

        private string commentaire;
        public string Commentaire { get => MonMedia.Commentaire; set => SetProperty(ref commentaire, value); }

        private string description;
        public string Description { get => MonMedia.Description; set => SetProperty(ref description, value); }

        private int ageMini;
        public int AgeMini { get => MonMedia.AgeMinimum; set => SetProperty(ref ageMini, value); }

        private int note;
        public int Note { get => MonMedia.Note; set => SetProperty(ref note, value); }

        private bool vu = false;
        public bool Vu { get => MonMedia.Vu; set => SetProperty(ref vu, value); }

        private bool supportPhysique = false;
        public bool SupportPhysique { get => MonMedia.SupportPhysique; set => SetProperty(ref supportPhysique, value); }

        private bool supportNumerique = false;
        public bool SupportNumerique { get => MonMedia.SupportNumerique; set => SetProperty(ref supportNumerique, value); }

        private DateTime annee;
        public DateTime Annee { get => MonMedia.DateSortie;  set => SetProperty(ref annee, value); }

        private TimeSpan duree;
        public TimeSpan Duree { get => MonMedia.Duree; set => SetProperty(ref duree, value); }

        private ELangue langueVo;
        public ELangue LangueVo { get => MonMedia.LangueVO; set => SetProperty(ref langueVo, value); }

        private ELangue langueSousTitre;
        public ELangue LangueSousTitre { get => MonMedia.SousTitre; set => SetProperty(ref langueSousTitre, value); }

        private ELangue langueMedia;
        public ELangue LangueMedia { get => MonMedia.LangueMedia; set => SetProperty(ref langueMedia, value); }

   

        private Genre genre;
        public Genre Genre { get => genre; set => SetProperty(ref genre, value); }

        private Genre sousGenre;
        public Genre SousGenre { get => sousGenre; set => SetProperty(ref sousGenre, value); }

        private async void RecuperationGenreMedia()
        {
            var context = await db.VideoTDbContext.GetCurrent();

            List<GenreMedia> ListGenresMedia = context.GenreMedias.Where(me => me.IdMedia == MonMedia.Id).ToList();

            if (ListGenresMedia.Count > 0 && ListGenresMedia[0] != null)
            {
                Genre = context.Genres.Where(gm => gm.Id == ListGenresMedia[0].IdGenre).First();
            }
            if (ListGenresMedia.Count > 1 && ListGenresMedia[1] != null)
            {
                SousGenre = context.Genres.Where(gm => gm.Id == ListGenresMedia[1].IdGenre).First();
            }
        }

    }
}
