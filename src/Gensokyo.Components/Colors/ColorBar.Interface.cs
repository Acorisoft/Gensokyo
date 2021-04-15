using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Gensokyo.Components.Colors
{
    /// <summary>
    /// <see cref="IColorBar"/>
    /// </summary>
    public interface IColorBar
    {
        /// <summary>
        /// 
        /// </summary>
        Brush Brush { get; }

        /// <summary>
        /// 
        /// </summary>
        Color Color { get; }
        event RoutedEventHandler BrushChanged;
    }
}
