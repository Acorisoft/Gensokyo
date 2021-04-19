using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gensokyo.Xaml.Converters
{
    public abstract class ColorBaseConverter : GenericConverterBase<string, SolidColorBrush>
    {
        protected abstract void SetOpacity(Brush brush);

        protected override sealed object ConvertBackCore(SolidColorBrush brush, object parameter, CultureInfo culture)
        {

            if (ColorConverters.StringCache.TryGetValue(brush, out string value))
            {
                return value;
            }
            else
            {
                value = brush.ToString();

                if (ColorConverters.StringCache.TryAdd(brush, value))
                {
                    return value;
                }
                else
                {
                    return "#007ACC";
                }

            }
        }

        protected override sealed object ConvertBackFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "#007ACC";
        }

        protected override sealed object ConvertFromCore(string value, object parameter, CultureInfo culture)
        {
            if (ColorConverters.BrushCache.TryGetValue(value, out var brush))
            {
                return brush;
            }
            else
            {
                brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value));
                
                if (ColorConverters.BrushCache.TryAdd(value, brush))
                {
                    ColorConverters.StringCache.TryAdd(brush, value);
                    SetOpacity(brush);
                }
                else
                {

                }

                return brush;
            }
        }

        protected override sealed object ConvertFromFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#007ACC"));

            if (ColorConverters.BrushCache.TryAdd("#007ACC", brush))
            {
                ColorConverters.StringCache.TryAdd(brush, "#007ACC");
                SetOpacity(brush);
            }
            else
            {

            }

            return brush;
        }
    }
}
