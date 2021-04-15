using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gensokyo.Xaml.Converters
{
    public abstract class GenericConverterBase<TFrom, TBack> : ConverterBase
    {
        protected override sealed object ConvertFromCore(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TFrom genericValue)
            {
                return ConvertFromCore(genericValue, parameter, culture);
            }
            return ConvertFromFallbackValue(value, targetType, parameter, culture);
        }
        protected override sealed object ConvertBackCore(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TBack genericValue)
            {
                return ConvertBackCore(genericValue, parameter, culture);
            }
            return ConvertBackFallbackValue(value, targetType, parameter, culture);
        }
        protected abstract object ConvertFromCore(TFrom value, object parameter, CultureInfo culture);
        protected abstract object ConvertBackCore(TBack value, object parameter, CultureInfo culture);
        protected abstract object ConvertFromFallbackValue(object value, Type targetType, object parameter, CultureInfo culture);
        protected abstract object ConvertBackFallbackValue(object value, Type targetType, object parameter, CultureInfo culture);
    }
}