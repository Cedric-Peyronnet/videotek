using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        FilmMain FM = new FilmMain();
        SerieMain SM = new SerieMain();
        Accueil AC = new Accueil();

        public MainWindow()
        {
            InitializeComponent();
           
            btnAccueil.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

            Main.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
      
        private void btnClickFilm(object sender, RoutedEventArgs e)
        {
            Main.Content = FM;
          
        }

        private void btnClickSerie(object sender, RoutedEventArgs e)
        {
            Main.Content = SM;
        }

        private void btnClickAccueil(object sender, RoutedEventArgs e)
        {
            Main.Content = AC;
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Main.Content.Equals(FM))
            {
                Ajout popup = new Ajout();
                popup.ShowDialog();
            }

            
        }
    }
}
