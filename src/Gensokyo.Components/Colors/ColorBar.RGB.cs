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

namespace Gensokyo.Components.Colors
{
    public partial class RGBColorBar : ColorBar, IColorBar
    {
        static RGBColorBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RGBColorBar), new FrameworkPropertyMetadata(typeof(RGBColorBar)));
        }

        public RGBColorBar() : base()
        {
        }

        protected override void OnColorChanged(double item1Val, double item2Value, double item3Value)
        {
            var color =  Color.FromRgb((byte)item1Val, (byte)item2Value, (byte)item3Value);
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
