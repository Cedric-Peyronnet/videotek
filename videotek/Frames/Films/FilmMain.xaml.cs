using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using videotek.Classes;

namespace videotek.Frames.Films
{
    /// <summary>
    /// Logique d'interaction pour FilmMain.xaml
    /// </summary>
    public partial class FilmMain : Page
    {

        public FilmMain()
        {
            InitializeComponent();
            InitialisationValeursConsultationAsync();

        }
        private async void InitialisationValeursConsultationAsync()
        {
            var context = await db.VideoTDbContext.GetCurrent();
            List<Media> films = context.Medias.ToList();
            
            /*
            media.FilmList = new ObservableCollection<Media>();
            foreach (Media film in films)
                FilmList.Add(film);
            test.ItemsSource = films;*/
        }
        
       
    }
}
