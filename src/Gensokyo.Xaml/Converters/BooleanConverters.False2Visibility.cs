using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gensokyo.Xaml.Converters
{
        public sealed class False2VisibilityConverter : GenericConverterBase<bool, Visibility>
        {
            protected override sealed object ConvertBackCore(Visibility value, object parameter, CultureInfo culture)
            {
                return value == Visibility.Visible ? BooleanBoxes.False : BooleanBoxes.True;
            }
            protected override sealed object ConvertBackFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return BooleanBoxes.False;
            }
            protected override sealed object ConvertFromCore(bool value, object parameter, CultureInfo culture)
            {
                return value ? VisibilityBoxes.Collapsed : VisibilityBoxes.Visible;
            }
            protected override sealed object ConvertFromFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return VisibilityBoxes.Collapsed;
            }
        }
    
}
