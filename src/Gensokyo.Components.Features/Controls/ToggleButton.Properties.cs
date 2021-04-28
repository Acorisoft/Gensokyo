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
        public object Icon
        {
            get => (object)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

    }
    partial class ToggleState
    {
        public object PositiveValue
        {
            get => (object)GetValue(PositiveValueProperty);
            set => SetValue(PositiveValueProperty, value);
        }

        public object NegativeValue
        {
            get => (object)GetValue(NegativeValueProperty);
            set => SetValue(NegativeValueProperty, value);
        }

        public Brush Negative
        {
            get => (Brush)GetValue(NegativeProperty);
            set => SetValue(NegativeProperty, value);
        }

        public Brush Positive
        {
            get => (Brush)GetValue(PositiveProperty);
            set => SetValue(PositiveProperty, value);
        }


        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

    }

    partial class ToggleValue
    {
        public object CurrentValue
        {
            get => (object)GetValue(CurrentValueProperty);
            private set => SetValue(CurrentValuePropertyKey, value);
        }
    }
}
