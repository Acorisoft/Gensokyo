using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gensokyo.Xaml.Converters
{
    public class DynamicColorAccentConverter : ColorBaseConverter
    {
        protected override void SetOpacity(Brush brush, ref Color color)
        {
            color.A = (byte)(255 * Opacity);
            brush.Opacity = Opacity;
        }

        public double Opacity { get; set; }
    }
}
