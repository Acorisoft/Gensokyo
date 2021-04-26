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
    partial class IxContentControl
    {

        public static readonly DependencyProperty SamplerProperty = DependencyProperty.Register(
            "Sampler",
            typeof(DispatcherTimer),
            typeof(IxContentControl),
            new PropertyMetadata(null,OnSamplerChanged));


        public static readonly DependencyProperty IsStandaloneProperty = DependencyProperty.Register(
            "IsStandalone",
            typeof(bool),
            typeof(IxContentControl),
            new PropertyMetadata(BooleanBoxes.Boxes(false), OnIsStandableChanged));


        public static readonly DependencyProperty EasingFunctionProperty = DependencyProperty.Register(
            "EasingFunction",
            typeof(EasingFunctionBase),
            typeof(IxContentControl),
            new PropertyMetadata(null));


        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register(
            "Direction",
            typeof(ExpandDirection),
            typeof(IxContentControl),
            new PropertyMetadata(ExpandDirection.Down, OnDirectionChanged));


        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
            "IsOpen",
            typeof(bool),
            typeof(IxContentControl),
            new PropertyMetadata(BooleanBoxes.Boxes(false),OnIsOpenChanged));

        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ixContent = (IxContentControl)d;
            if ((bool)e.NewValue)
            {
                if (ixContent._Delta < 1)
                {
                    ixContent.IxState = InteractiveContentState.Expanding;
                }
            }
            else
            {
                if(ixContent._Delta > 0)
                {
                    ixContent.IxState = InteractiveContentState.Collapsing;
                }
            }
        }

        private static void OnDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var direction = (ExpandDirection)e.NewValue;
            var tcc = (IxContentControl)d;
            switch (direction)
            {
                case ExpandDirection.Down:
                    tcc._Transformer = new Top2BottomTransformer();
                    break;
                case ExpandDirection.Up:
                    tcc._Transformer = new Bottom2TopTransformer();
                    break;
                case ExpandDirection.Left:
                    tcc._Transformer = new Right2LeftTransformer();
                    break;
                case ExpandDirection.Right:
                    tcc._Transformer = new Left2RightTransformer();
                    break;
            }
        }

        private static void OnSamplerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is DispatcherTimer)
            {
                var ixContent = (IxContentControl)d;
                ixContent.OnSamplerChanged(e.NewValue as DispatcherTimer, e.OldValue as DispatcherTimer);
            }
        }

        private static void OnIsStandableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                d.SetValue(SamplerProperty, new DispatcherTimer(DispatcherPriority.Render, d.Dispatcher));
            }
        }
    }
}
