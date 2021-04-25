using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gensokyo.Xaml.Converters
{
    public class DegreeColorConverter : ColorBaseConverter
    {
        protected override void SetOpacity(ref Color color)
        {
            color.A = (byte)(255 * Opacity);
        }

        public double Opacity { get; set; }
    }
}
