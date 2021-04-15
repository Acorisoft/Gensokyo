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
using System.Windows.Threading;

namespace Gensokyo.Components.Colors
{
    public abstract partial class ColorBar : Control, IColorBar
    {
        public const string PART_Item1Name      = "PART_Item1";
        public const string PART_Item2Name      = "PART_Item2";
        public const string PART_Item3Name      = "PART_Item3";
        public const string PART_ItemValue1Name = "PART_ItemValue1";
        public const string PART_ItemValue2Name = "PART_ItemValue2";
        public const string PART_ItemValue3Name = "PART_ItemValue3";

        static ColorBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorBar), new FrameworkPropertyMetadata(typeof(ColorBar)));

            BrushPropertyKey = DependencyProperty.RegisterReadOnly("Brush", typeof(Brush), typeof(ColorBar), new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Red)));
            ColorPropertyKey = DependencyProperty.RegisterReadOnly("Color", typeof(Color), typeof(ColorBar), new PropertyMetadata(System.Windows.Media.Colors.Red));

            BrushProperty = BrushPropertyKey.DependencyProperty;
            ColorProperty = ColorPropertyKey.DependencyProperty;
        }

        private Slider PART_Item1;
        private Slider PART_Item2;
        private Slider PART_Item3;
        private TextBox PART_ItemValue1;
        private TextBox PART_ItemValue2;
        private TextBox PART_ItemValue3;

        private readonly DispatcherTimer _Timer;
        private bool _isColorChanged;

        public ColorBar()
        {
            _Timer = new DispatcherTimer(TimeSpan.FromMilliseconds(16), DispatcherPriority.Normal, (o, e) =>
            {
                if (_isColorChanged)
                {
                    _isColorChanged = false;

                    OnColorChanged(PART_Item1?.Value ?? 0,
                                   PART_Item2?.Value ?? 100,
                                   PART_Item3?.Value ?? 100);
                }

            }, Dispatcher);
            _Timer.Start();

            this.Unloaded += (o, e) => {
                _Timer.Stop();

                PART_Item1.ValueChanged -= OnFireColorChanged;
                PART_Item2.ValueChanged -= OnFireColorChanged;
                PART_Item3.ValueChanged -= OnFireColorChanged; 
                PART_ItemValue1.TextChanged -= OnValueChanged;
                PART_ItemValue2.TextChanged -= OnValueChanged;
                PART_ItemValue3.TextChanged -= OnValueChanged;
            };
        }

        protected void OnFireColorChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _isColorChanged = true;
        }

        protected virtual void OnColorChanged(double item1Val,double item2Value,double item3Value)
        {

        }
        protected void OnValueChanged(object sender, TextChangedEventArgs e)
        {
            bool b1 = false,b2 = false,b3 = false;

            if (double.TryParse(PART_ItemValue1.Text, out var val1))
            {
                PART_Item1.Value = val1;
                b1 = true;
            }

            if (double.TryParse(PART_ItemValue2.Text, out val1))
            {
                PART_Item2.Value = val1;
                b2 = true;
            }

            if (double.TryParse(PART_ItemValue3.Text, out val1))
            {
                PART_Item3.Value = val1;
                b3 = true;
            }

            _isColorChanged = b1 || b2 || b3;
        }

        public override void OnApplyTemplate()
        {
            PART_Item1 = GetTemplateChild(PART_Item1Name) as Slider;
            PART_Item2 = GetTemplateChild(PART_Item2Name) as Slider;
            PART_Item3 = GetTemplateChild(PART_Item3Name) as Slider;
            PART_ItemValue1 = GetTemplateChild(PART_ItemValue1Name) as TextBox;
            PART_ItemValue2 = GetTemplateChild(PART_ItemValue2Name) as TextBox;
            PART_ItemValue3 = GetTemplateChild(PART_ItemValue3Name) as TextBox;

            PART_Item1.ValueChanged += OnFireColorChanged;
            PART_Item2.ValueChanged += OnFireColorChanged;
            PART_Item3.ValueChanged += OnFireColorChanged;
            PART_ItemValue1.TextChanged += OnValueChanged;
            PART_ItemValue2.TextChanged += OnValueChanged;
            PART_ItemValue3.TextChanged += OnValueChanged;
        }
    }
}
