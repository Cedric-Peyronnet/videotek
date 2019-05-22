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

namespace videotek.Frames.Common
{
    /// <summary>
    /// Logique d'interaction pour MenuGestion.xaml
    /// </summary>
    public partial class MenuGestion : Page
    {
        public MenuGestion()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button_Click popup = new Button_Click();
            popup.ShowDialog();
        }
    }
}
