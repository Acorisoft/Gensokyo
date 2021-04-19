using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gensokyo.Xaml.Converters
{
    public class Color90AccentConverter : ColorBaseConverter
    {
        protected override void SetOpacity(Brush brush)
        {
            brush.Opacity = 0.9d;
        }
    }
}
