using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UFODronner.Converters
{
    public class OneDivideValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic v = value;
            try
            {
                return 1 / v;
            }
            catch
            {
                return 1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic v = value;
            try
            {
                return 1 / v;
            }
            catch
            {
                return value;
            }
        }
    }
}
