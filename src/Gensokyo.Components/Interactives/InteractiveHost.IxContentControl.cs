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
    public class IxContentControl : ContentControl
    {
        protected abstract class TranslateTransformer
        {
            public abstract void Transform(FrameworkElement parent, FrameworkElement element, double delta);
        }

        protected sealed class Top2BottomTransformer : TranslateTransformer
        {
            public override void Transform(FrameworkElement parent, FrameworkElement element, double delta)
            {
                var height = element.ActualHeight;
                var transform = new TranslateTransform(0, -height + height * delta);
                element.RenderTransform = transform;
            }
        }

        protected sealed class Bottom2TopTransformer : TranslateTransformer
        {
            public override void Transform(FrameworkElement parent, FrameworkElement element, double delta)
            {
                var height = element.ActualHeight;
                var transform = new TranslateTransform(0, height - height * delta);
                element.RenderTransform = transform;
            }
        }

        protected sealed class Left2RightTransformer : TranslateTransformer
        {
            public override void Transform(FrameworkElement parent, FrameworkElement element, double delta)
            {
                var width = element.ActualWidth;
                var transform = new TranslateTransform(-width + delta * width,0);
                element.RenderTransform = transform;
            }
        }

        protected sealed class Right2LeftTransformer : TranslateTransformer
        {
            public override void Transform(FrameworkElement parent, FrameworkElement element, double delta)
            {
                var width = element.ActualHeight;
                var transform = new TranslateTransform(parent.ActualWidth - width * delta, 0);
                element.RenderTransform = transform;
            }
        }

        private TranslateTransformer _Transformer;
        private ContentPresenter _Presenter;

        public IxContentControl()
        {
            _Transformer = new Top2BottomTransformer();
            this.SizeChanged += OnSizeChanged;
        }

        protected virtual void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!(_Presenter is null))
            {
                _Transformer?.Transform(this, _Presenter, Delta);
            }
        }

        public override void OnApplyTemplate()
        {
            var count = VisualTreeHelper.GetChildrenCount(this);
            for (int i = 0; i < count; i++)
            {
                if (VisualTreeHelper.GetChild(this, i) is ContentPresenter presenter)
                {
                    _Presenter = presenter;
                    _Transformer?.Transform(this, presenter, Delta);
                }
            }
            base.OnApplyTemplate();
        }

        protected override void OnChildDesiredSizeChanged(UIElement child)
        {
            if (!(_Presenter is null))
            {
                _Transformer?.Transform(this, _Presenter, Delta);
            }
            base.OnChildDesiredSizeChanged(child);
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (!(_Presenter is null))
            {
                _Transformer?.Transform(this, _Presenter, Delta);
            }
            base.OnContentChanged(oldContent, newContent);
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

        private static void OnDeltaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var delta = (double)e.NewValue;
            var parent = (IxContentControl)d;
            var element = parent._Presenter;
            var transformer = parent._Transformer;
            if (!(element is null) && !(parent.ParentElement is null))
            {
                transformer?.Transform(parent.ParentElement, element, delta);
            }
        }


        public ExpandDirection Direction
        {
            get => (ExpandDirection)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }

        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register(
            "Direction",
            typeof(ExpandDirection),
            typeof(IxContentControl),
            new PropertyMetadata(ExpandDirection.Down, OnDirectionChanged));

        public FrameworkElement ParentElement { get; set; }
        public double Delta
        {
            get => (double)GetValue(DeltaProperty);
            set => SetValue(DeltaProperty, value);
        }

        public static readonly DependencyProperty DeltaProperty = DependencyProperty.Register(
            "Delta",
            typeof(double),
            typeof(IxContentControl),
            new PropertyMetadata(0d, OnDeltaChanged));

    }

}
