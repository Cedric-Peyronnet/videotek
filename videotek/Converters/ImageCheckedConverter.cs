using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace videotek.Converters
{
    class ImageCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.Equals("false") )
            {
                string name = (string)value;

                var requestImage = new Image()
                {
                    Height = 16,
                    Width = 16,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                };

                requestImage.Source = new BitmapImage(new Uri("./Images/notChecked.png"));
                return requestImage;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value is bool ? !(bool)value : false;
        }     
    }
}
