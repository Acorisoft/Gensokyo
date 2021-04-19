using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gensokyo.Xaml.Converters
{
    public class Color50AccentConverter : ColorBaseConverter
    {
        protected override void SetOpacity(Brush brush, ref Color color)
        {
            color.A = (byte)(255 * 0.6d);
        }
    }
}
