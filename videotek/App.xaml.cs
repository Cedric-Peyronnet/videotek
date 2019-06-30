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
            Initialisation init = new Initialisation();

            init.RemplissageGenre();
            init.remplissageSerieFilm();
            
        }

    }
}
