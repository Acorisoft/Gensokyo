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

namespace Gensokyo.Components.Windows
{
    partial class InteractiveWindow
    {
        public object Dialog
        {
            get => GetValue(DialogProperty);
            private set => SetValue(DialogPropertyKey, value);
        }

        public object LeftSide
        {
            get => (object)GetValue(LeftSideProperty);
            set => SetValue(LeftSideProperty, value);
        }

        public DataTemplate LeftSideTemplate
        {
            get => (DataTemplate)GetValue(LeftSideTemplateProperty);
            set => SetValue(LeftSideTemplateProperty, value);
        }

        public DataTemplateSelector LeftSideTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(LeftSideTemplateSelectorProperty);
            set => SetValue(LeftSideTemplateSelectorProperty, value);
        }

        public string LeftSideStringFormat
        {
            get => (string)GetValue(LeftSideStringFormatProperty);
            set => SetValue(LeftSideStringFormatProperty, value);
        }

        public object RightSide
        {
            get => (object)GetValue(RightSideProperty);
            set => SetValue(RightSideProperty, value);
        }

        public DataTemplate RightSideTemplate
        {
            get => (DataTemplate)GetValue(RightSideTemplateProperty);
            set => SetValue(RightSideTemplateProperty, value);
        }

        public DataTemplateSelector RightSideTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(RightSideTemplateSelectorProperty);
            set => SetValue(RightSideTemplateSelectorProperty, value);
        }

        public string RightSideStringFormat
        {
            get => (string)GetValue(RightSideStringFormatProperty);
            set => SetValue(RightSideStringFormatProperty, value);
        }

        public object TopSide
        {
            get => (object)GetValue(TopSideProperty);
            set => SetValue(TopSideProperty, value);
        }

        public DataTemplate TopSideTemplate
        {
            get => (DataTemplate)GetValue(TopSideTemplateProperty);
            set => SetValue(TopSideTemplateProperty, value);
        }

        public DataTemplateSelector TopSideTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(TopSideTemplateSelectorProperty);
            set => SetValue(TopSideTemplateSelectorProperty, value);
        }

        public string TopSideStringFormat
        {
            get => (string)GetValue(TopSideStringFormatProperty);
            set => SetValue(TopSideStringFormatProperty, value);
        }

        public object BottomSide
        {
            get => (object)GetValue(BottomSideProperty);
            set => SetValue(BottomSideProperty, value);
        }

        public DataTemplate BottomSideTemplate
        {
            get => (DataTemplate)GetValue(BottomSideTemplateProperty);
            set => SetValue(BottomSideTemplateProperty, value);
        }

        public DataTemplateSelector BottomSideTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(BottomSideTemplateSelectorProperty);
            set => SetValue(BottomSideTemplateSelectorProperty, value);
        }

        public string BottomSideStringFormat
        {
            get => (string)GetValue(BottomSideStringFormatProperty);
            set => SetValue(BottomSideStringFormatProperty, value);
        }

        public Brush Color
        {
            get => (Brush)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public object TitleBar
        {
            get => (object)GetValue(TitleBarProperty);
            set => SetValue(TitleBarProperty, value);
        }

        public DataTemplate TitleBarTemplate
        {
            get => (DataTemplate)GetValue(TitleBarTemplateProperty);
            set => SetValue(TitleBarTemplateProperty, value);
        }

        public DataTemplateSelector TitleBarTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(TitleBarTemplateSelectorProperty);
            set => SetValue(TitleBarTemplateSelectorProperty, value);
        }

        public string TitleBarStringFormat
        {
            get => (string)GetValue(TitleBarStringFormatProperty);
            set => SetValue(TitleBarStringFormatProperty, value);
        }

    }
}
