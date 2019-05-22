using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using videotek.Classes;

namespace videotek.Frames.Common
{
    /// <summary>
    /// Logique d'interaction pour Ajout.xaml
    /// </summary>
    public partial class Button_Click : Window
    {
        
        public Button_Click()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private async Task EnregistrerAsync()
        {
            var context = await db.VideoTDbContext.GetCurrent();

            context.Add(new Media()
            {
                Titre = titre.Text
            }
            );

            await context.SaveChangesAsync();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            EnregistrerAsync();
        }
    }
}
