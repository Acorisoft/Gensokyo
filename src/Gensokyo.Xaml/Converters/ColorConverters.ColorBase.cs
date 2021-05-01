using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gensokyo.Xaml.Converters
{
    public class DegreeBrushConverter : GenericConverterBase<Brush, SolidColorBrush>
    {
        protected override object ConvertBackCore(SolidColorBrush value, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush scb) 
            {
                if (ColorConverters.StringCache.TryGetValue(scb, out Color color))
                {
                    return color.ToString();
                }
                else
                {
                    if (ColorConverters.StringCache.TryAdd(scb, scb.Color))
                    {
                        return value.ToString();
                    }
                    else
                    {
                        return "#007ACC";
                    }

                }
            }

            return value.ToString();
        }

        protected override object ConvertBackFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        protected override sealed object ConvertFromCore(Brush value, object parameter, CultureInfo culture)
        {
            if(value is SolidColorBrush scb)
            {
                var color = scb.Color;
                if (ColorConverters.BrushCache.TryGetValue(color, out var brush))
                {
                    return brush;
                }
                else
                {
                    brush = new SolidColorBrush(color);

                    if (ColorConverters.BrushCache.TryAdd(color, brush))
                    {
                        ColorConverters.StringCache.TryAdd(brush, color);
                    }
                    else
                    {

                    }

                    return brush;
                }
            }

            return ConvertFromFallbackValue(value, value?.GetType(), parameter, culture);
        }

        protected override object ConvertFromFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public double Opacity { get; set; }
    }
    public abstract class ColorBaseConverter : GenericConverterBase<string, SolidColorBrush>
    {
        protected abstract void SetOpacity(ref Color color);

        protected override sealed object ConvertBackCore(SolidColorBrush brush, object parameter, CultureInfo culture)
        {
            if (ColorConverters.StringCache.TryGetValue(brush, out Color value))
            {
                return value.ToString();
            }
            else
            {
                if (ColorConverters.StringCache.TryAdd(brush, value))
                {
                    return value.ToString();
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
            var color = (Color)ColorConverter.ConvertFromString(value);

            if (ColorConverters.BrushCache.TryGetValue(color, out var brush))
            {
                return brush;
            }
            else
            {
                SetOpacity(ref color);
                brush = new SolidColorBrush(color);
                
                if (ColorConverters.BrushCache.TryAdd(color, brush))
                {
                    ColorConverters.StringCache.TryAdd(brush, color);
                }
                else
                {

                }

                return brush;
            }
        }

        protected override sealed object ConvertFromFallbackValue(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)ColorConverter.ConvertFromString("#007ACC");
            var brush = new SolidColorBrush(color);

            if (ColorConverters.BrushCache.TryAdd(color, brush))
            {
                SetOpacity(ref color);
                ColorConverters.StringCache.TryAdd(brush, color);
            }
            else
            {

            }

            return brush;
        }
    }
}
