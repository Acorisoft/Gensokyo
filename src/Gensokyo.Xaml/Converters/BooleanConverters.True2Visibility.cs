using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gensokyo.Xaml.Converters
{

    public sealed class True2VisibilityConverter : GenericConverterBase<bool, Visibility>
    {
        protected override sealed object ConvertBackCore(Visibility value, object parameter, CultureInfo culture)
        {
            return value == Visibility.Visible ? BooleanBoxes.True : BooleanBoxes.False;
        }
        protected override sealed object ConvertBackFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return BooleanBoxes.False;
        }
        protected override sealed object ConvertFromCore(bool value, object parameter, CultureInfo culture)
        {
            return value ? VisibilityBoxes.Visible : VisibilityBoxes.Collapsed;
        }
        protected override sealed object ConvertFromFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return VisibilityBoxes.Collapsed;
        }
    }
}
