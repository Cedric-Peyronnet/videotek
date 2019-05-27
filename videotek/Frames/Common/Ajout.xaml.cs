using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using videotek.Classes;
using videotek.ViewModels;

namespace videotek.Frames.Common
{
    /// <summary>
    /// Logique d'interaction pour Ajout.xaml
    /// </summary>
    public partial class Ajout : Window
    {
        
        public Ajout()
        {
            this.DataContext = this;
            InitializeComponent();
        }
  
        
    

        Regex regexEntierPositif = new Regex("[^0-9]+");

        private void Note_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regexEntierPositif.IsMatch(e.Text);
        }    

        private void AgeMini_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regexEntierPositif.IsMatch(e.Text);
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
