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

        private async void EnregistrerAsync()
        {
            var context = await db.VideoTDbContext.GetCurrent();

            context.Add(new Media()
            {
                Titre = titre.Text,
                AgeMinimum = int.Parse(ageMini.Text),
                Commentaire = commentaire.Text,
                DateSortie = DateTime.Parse(date.Text),
                Description = description.Text,
                Duree = TimeSpan.Parse(dure.Text),
                LangueVO = (Langue)Enum.Parse(typeof(Langue), langueVO.Text),
                SousTitre = (Langue)Enum.Parse(typeof(Langue), sousTitres.Text),
                LangueMedia = (Langue)Enum.Parse(typeof(Langue), langue.Text),

            }
            );

            await context.SaveChangesAsync();
            
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
            EnregistrerAsync();
            this.Close();
        }
    }
}
