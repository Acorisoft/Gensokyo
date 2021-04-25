using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Gensokyo.Xaml;

namespace Gensokyo.Components.Interactives
{
    partial class InteractiveHost
    {
        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register(
            "Direction",
            typeof(ExpandDirection),
            typeof(InteractiveHost),
            new PropertyMetadata(ExpandDirection.Down));


        public static readonly DependencyProperty InteractiveStringFormatProperty = DependencyProperty.Register(
            "InteractiveStringFormat",
            typeof(string),
            typeof(InteractiveHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty InteractiveTemplateSelectorProperty = DependencyProperty.Register(
            "InteractiveTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(InteractiveHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty InteractiveTemplateProperty = DependencyProperty.Register(
            "InteractiveTemplate",
            typeof(DataTemplate),
            typeof(InteractiveHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty InteractiveProperty = DependencyProperty.Register(
            "Interactive",
            typeof(object),
            typeof(InteractiveHost),
            new PropertyMetadata(null));
        
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
            "IsOpen",
            typeof(bool),
            typeof(InteractiveHost),
            new PropertyMetadata(BooleanBoxes.Boxes(false),OnIsOpenChanged));

        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var host = (InteractiveHost)d;
            var condition = (bool)e.NewValue;
            if (condition) host._Recognition.ForceExpanding();
        }
    }
}
