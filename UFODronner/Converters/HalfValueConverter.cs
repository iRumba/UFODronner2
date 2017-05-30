using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UFODronner.Converters
{
    public class HalfValueConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic v = value;
            try
            {
                return v / 2;
            }
            catch
            {
                return 0;
            }
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic v = value;
            try
            {
                return v * 2;
            }
            catch
            {
                return 0;
            }
        }
    }
}
