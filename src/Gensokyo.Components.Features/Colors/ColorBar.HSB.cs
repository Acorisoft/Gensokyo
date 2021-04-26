using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Gensokyo.Xaml.ColorSpace;

namespace Gensokyo.Components.Colors
{
    /// <summary>
    /// <see cref="HSBColorBar"/> 类型表示一个HSB色彩控件颜色条。
    /// </summary>
    [TemplatePart(Name = PART_Item1Name)]
    [TemplatePart(Name = PART_Item2Name)]
    [TemplatePart(Name = PART_Item3Name)]
    public partial class HSBColorBar : ColorBar, IColorBar
    {
        static HSBColorBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HSBColorBar), new FrameworkPropertyMetadata(typeof(HSBColorBar)));
        }

        public HSBColorBar() : base()
        {
        }



        protected override void OnColorChanged(double item1Val, double item2Value, double item3Value)
        {
            var color = HSBColorSpace.FromHSB<Color>(item1Val,
                                                     item2Value / 100d,
                                                     item3Value / 100d,
                                                     (r, g, b) => Color.FromRgb((byte)r, (byte)g, (byte)b));
            var brush = new SolidColorBrush(color);
            SetValue(BrushPropertyKey, brush);
            SetValue(ColorPropertyKey, color);
            RaiseEvent(new RoutedEventArgs
            {
                RoutedEvent = BrushChangedEvent
            });
        }
    }
}
