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
    public partial class ToggleValue : ToggleState
    {
        static ToggleValue()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleValue), new FrameworkPropertyMetadata(typeof(ToggleValue)));
            CurrentValuePropertyKey =  DependencyProperty.RegisterReadOnly(
                                        "CurrentValue",
                                        typeof(object),
                                        typeof(ToggleValue),
                                        new PropertyMetadata(null));
            CurrentValueProperty = CurrentValuePropertyKey.DependencyProperty;
        }

        protected override void OnToggle()
        {
            CurrentValue = IsChecked == true ? PositiveValue : NegativeValue;
            base.OnToggle();
        }
    }
}
