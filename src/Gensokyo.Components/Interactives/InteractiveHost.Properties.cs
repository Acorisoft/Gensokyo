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
    partial class InteractiveHost
    {
        public object Interactive
        {
            get => (object)GetValue(InteractiveProperty);
            set => SetValue(InteractiveProperty, value);
        }

        public DataTemplate InteractiveTemplate
        {
            get => (DataTemplate)GetValue(InteractiveTemplateProperty);
            set => SetValue(InteractiveTemplateProperty, value);
        }

        public DataTemplateSelector InteractiveTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(InteractiveTemplateSelectorProperty);
            set => SetValue(InteractiveTemplateSelectorProperty, value);
        }

        public string InteractiveStringFormat
        {
            get => (string)GetValue(InteractiveStringFormatProperty);
            set => SetValue(InteractiveStringFormatProperty, value);
        }


        public ExpandDirection Direction
        {
            get => (ExpandDirection)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }


        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }


    }
}
