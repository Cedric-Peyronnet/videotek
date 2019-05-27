using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace videotek.Converters
{
    public class TestConverter : IValueConverter
    {

        // En entrée un boolean true ou false, en sortie je suis true ou false
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is bool ))
                return "je suis false";

            return (bool)value ? "je suis true" : "je suis false";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is string))
                return false;

            return (string)value == "je suis true" ? true : false;
        }


        //fgdgfd
    }
}
