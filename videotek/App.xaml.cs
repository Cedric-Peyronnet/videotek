using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using videotek.Classes;

namespace videotek
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await db.VideoTDbContext.GetCurrent();
            RemplissageGenre();
            remplissageSerie();
            
        }

        private async void RemplissageGenre()
        {


            var context = await db.VideoTDbContext.GetCurrent();

            List<Genre> genre = context.Genres.ToList();

            if (genre.Count == 0)
            {
                Genre remplissageGenre = new Genre()
                {
                    Libelle = "Science Fiction"
                };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Fantaisie" };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Drame" };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Comédie" };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Horreur" };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Live action" };
                context.Add(remplissageGenre);
                await context.SaveChangesAsync();
            }


            await context.SaveChangesAsync();
        }
        private async void remplissageSerie()
        
        {
           
            var context = await db.VideoTDbContext.GetCurrent();
            List<Media> series = context.Medias.Where(m => m.Type == ETypeMedia.Serie).ToList();
            if (series.Count == 0)
            {     
                context.Medias.Add(new Media { Titre = "Game of thrones", Type = ETypeMedia.Serie});
               
                await context.SaveChangesAsync();
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "L'hiver vient", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 1 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "La route royal", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 2 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Lord Snow", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 3 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Infirmes, Bâtards et Choses brisées", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 4 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Le Loup et le Lion", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 5 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Une couronne dorée", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 6 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Gagner ou mourir", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 7 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Frapper d'estoc", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 8 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Baelor", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 9 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "De feu et de sang", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 10 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0),  Titre = "Le Nord se souvient", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 1 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Les Contrées nocturnes", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 2 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Ce qui est mort ne saurait mourir", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 3 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Le Jardin des os", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 4 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Le Fantôme d'Harrenhal", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 5 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Les Anciens et les Nouveaux Dieux", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 6 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Un homme sans honneur", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 7 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Le Prince de Winterfell", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 8 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "La Néra", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 9 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Valar Morghulis", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 10 });
                await context.SaveChangesAsync();

                 series = context.Medias.Where(m => m.Type == ETypeMedia.Serie).ToList();
                List<Episode> episodes = context.Episodes.ToList();
                foreach(Media serie in series)
                {
                    for(int i = 0; i < 21; i++)
                    {
                        context.EpisodesMedia.Add(new EpisodeMedia { IdMedia = serie.Id, IdEpisode = episodes[i].Id });
                    }
                }
                await context.SaveChangesAsync();              
            }
        }
    }
}
