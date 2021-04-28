using Gensokyo.Xaml;
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

namespace Gensokyo.Components.Controls
{
    partial class ToggleSwitch
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon",
            typeof(object),
            typeof(ToggleSwitch),
            new PropertyMetadata(null));

    }

    partial class ToggleState
    {

        public static readonly DependencyProperty NegativeValueProperty =  DependencyProperty.Register(
            "NegativeValue",
            typeof(object),
            typeof(ToggleState),
            new PropertyMetadata(null));

        public static readonly DependencyProperty PositiveValueProperty =  DependencyProperty.Register(
            "PositiveValue",
            typeof(object),
            typeof(ToggleState),
            new PropertyMetadata(null));


        public static readonly DependencyProperty PositiveProperty =  DependencyProperty.Register(
            "Positive",
            typeof(Brush),
            typeof(ToggleState),
            new PropertyMetadata(null));


        public static readonly DependencyProperty NegativeProperty =  DependencyProperty.Register(
            "Negative",
            typeof(Brush),
            typeof(ToggleState),
            new PropertyMetadata(null));

        public static readonly DependencyProperty CornerRadiusProperty =  DependencyProperty.Register(
            "CornerRadius",
            typeof(CornerRadius),
            typeof(ToggleState),
            new PropertyMetadata(Default.Value<CornerRadius>()));
    }

    partial class ToggleValue
    {
        public static readonly DependencyProperty CurrentValueProperty;
        public static readonly DependencyPropertyKey CurrentValuePropertyKey;

    }
}
