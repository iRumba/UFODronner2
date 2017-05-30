using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UFODronner.Converters
{
    public class HalfInversedValueConverter : HalfValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic res = base.Convert(value, targetType, parameter, culture);
            try
            {
                return -res;
            }
            catch
            {
                return 0;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            dynamic res = base.Convert(value, targetType, parameter, culture);
            try
            {
                return -res;
            }
            catch
            {
                return 0;
            }
        }
    }
}
