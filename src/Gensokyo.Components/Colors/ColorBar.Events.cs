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

namespace Gensokyo.Components.Colors
{
    partial class ColorBar
    {

        public static readonly RoutedEvent BrushChangedEvent = EventManager.RegisterRoutedEvent(
                  "BrushChanged",
                  RoutingStrategy.Bubble,
                  typeof(RoutedEventHandler),
                  typeof(ColorBar));

        public event RoutedEventHandler BrushChanged
        {
            add => AddHandler(BrushChangedEvent, value);
            remove => RemoveHandler(BrushChangedEvent, value);
        }
    }
}
