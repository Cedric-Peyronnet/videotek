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

            context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "L'hiver vient ", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 1 });
        //context.Episodes.ToList();
     

        await context.SaveChangesAsync();
        }
    }
}
