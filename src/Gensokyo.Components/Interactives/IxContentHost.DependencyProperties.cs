using Gensokyo.Xaml;
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

namespace Gensokyo.Components.Interactives
{
    partial class IxContentHost
    {

        public static readonly DependencyProperty LeftSideStringFormatProperty = DependencyProperty.Register(
            "LeftSideStringFormat",
            typeof(string),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty LeftSideTemplateSelectorProperty = DependencyProperty.Register(
            "LeftSideTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty LeftSideTemplateProperty = DependencyProperty.Register(
            "LeftSideTemplate",
            typeof(DataTemplate),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty RightSideStringFormatProperty = DependencyProperty.Register(
            "RightSideStringFormat",
            typeof(string),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty RightSideTemplateSelectorProperty = DependencyProperty.Register(
            "RightSideTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty RightSideTemplateProperty = DependencyProperty.Register(
            "RightSideTemplate",
            typeof(DataTemplate),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty RightSideProperty = DependencyProperty.Register(
            "RightSide",
            typeof(object),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TopSideProperty = DependencyProperty.Register(
            "TopSide",
            typeof(object),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TopSideStringFormatProperty = DependencyProperty.Register(
            "TopSideStringFormat",
            typeof(string),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TopSideTemplateSelectorProperty = DependencyProperty.Register(
            "TopSideTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TopSideTemplateProperty = DependencyProperty.Register(
            "TopSideTemplate",
            typeof(DataTemplate),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty LeftSideProperty = DependencyProperty.Register(
            "LeftSide",
            typeof(object),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty BottomSideStringFormatProperty = DependencyProperty.Register(
            "BottomSideStringFormat",
            typeof(string),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty BottomSideTemplateSelectorProperty = DependencyProperty.Register(
            "BottomSideTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty BottomSideTemplateProperty = DependencyProperty.Register(
            "BottomSideTemplate",
            typeof(DataTemplate),
            typeof(IxContentHost),
            new PropertyMetadata(null));

        public static readonly DependencyProperty BottomSideProperty = DependencyProperty.Register(
            "BottomSide",
            typeof(object),
            typeof(IxContentHost),
            new PropertyMetadata(null));
    }
}
