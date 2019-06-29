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

        private string genre;
        public string Genre { get => genre; set => SetProperty(ref genre, value); }

        private string sousGenre;
        public string SousGenre { get => sousGenre; set => SetProperty(ref sousGenre, value); }

        private async void RecuperationGenreMedia()
        {
            var context = await db.VideoTDbContext.GetCurrent();

            List<GenreMedia> ListGenresMedia = context.GenreMedias.Where(me => me.IdMedia == MonMedia.Id).ToList();

            if (ListGenresMedia.Count > 0 && ListGenresMedia[0] != null)
            {
                Genre genre = context.Genres.Where(gm => gm.Id == ListGenresMedia[0].IdGenre).First();
                Genre = genre.Libelle;
            }
            if (ListGenresMedia.Count > 1 && ListGenresMedia[1] != null)
            {
                Genre sousFenre = context.Genres.Where(gm => gm.Id == ListGenresMedia[1].IdGenre).First();
                Genre = sousFenre.Libelle;
            }
        }

    }
}
