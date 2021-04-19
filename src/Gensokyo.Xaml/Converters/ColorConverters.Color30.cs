﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gensokyo.Xaml.Converters
{
    public class Color30AccentConverter : ColorBaseConverter
    {
        protected override void SetOpacity(Brush brush)
        {
            brush.Opacity = 0.3d;
        }
    }
}
