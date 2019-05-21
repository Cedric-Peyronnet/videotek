using System;
using System.Collections.Generic;
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
using videotek.Frames.Common;
using videotek.Frames.Films;
using videotek.Frames.Series;

namespace videotek
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClickFilm(object sender, RoutedEventArgs e)
        {
            Main.Content = new FilmMain();
        }

        private void btnClickSerie(object sender, RoutedEventArgs e)
        {
            Main.Content = new SerieMain();
        }

        private void btnClickAccueil(object sender, RoutedEventArgs e)
        {
            Main.Content = new Accueil();
        }
    }
}
