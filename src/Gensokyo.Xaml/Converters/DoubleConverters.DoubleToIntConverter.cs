using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gensokyo.Xaml.Converters
{
    public sealed class DoubleToIntConverter : GenericConverterBase<double, int>
    {
        protected override object ConvertBackCore(int value, object parameter, CultureInfo culture)
        {
            return (double)value;
        }

        protected override object ConvertBackFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }

        protected override object ConvertFromCore(double value, object parameter, CultureInfo culture)
        {
            return (int)value;
        }

        protected override object ConvertFromFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
