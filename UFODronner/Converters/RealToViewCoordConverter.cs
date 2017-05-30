using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UFODronner.Converters
{
    public class RealToViewCoordConverter : IValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2)
                return 0;
            return GetValue(values[0]) / GetScale(values[1]);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetValue(value) / GetScale(parameter);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetValue(value) * GetScale(parameter);
        }

        double GetScale(object obj)
        {
            double def = 1;
            if (obj == null)
                return def;

            double res;

            return TryParseDouble(obj, out res) ? res : def;
        }

        double GetValue(object obj)
        {
            double def = 0;
            if (obj == null)
                return def;

            double res;

            return TryParseDouble(obj, out res) ? res : def;
        }

        bool TryParseDouble(object obj, out double res)
        {
            var str = obj?.ToString()
                .Replace(".", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
                .Replace(",", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator) ?? string.Empty;
            return double.TryParse(str, out res);
        }
    }
}
