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
    public enum InteractiveContentState
    {
        Idle,
        Dragging,
        Expanding,
        Collapsing
    }

    public interface IIxContentControl
    {
        /// <summary>
        /// 
        /// </summary>
        ExpandDirection Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        InteractiveContentState IxState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DispatcherTimer Sampler { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值表示当前的 <see cref="IIxContentControl"/> 是否单独使用。
        /// </summary>
        bool IsStandalone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        EasingFunctionBase EasingFunction { get; set; }
    }

    public partial class IxContentControl : ContentControl, IIxContentControl
    {
        #region Transformers

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


        #endregion Transformers

        private TranslateTransformer    _Transformer;
        private double                  _Delta;
        private ContentPresenter        _Presenter;

        public IxContentControl()
        {
            _Transformer = new Top2BottomTransformer();
            this.SizeChanged += OnSizeChanged;
        }

        void Sampling(object sender, EventArgs e)
        {
            switch (IxState)
            {
                case InteractiveContentState.Idle:
                    if(_Delta > .65)
                    {
                        IxState = InteractiveContentState.Expanding;
                    }
                    else if(_Delta < .65)
                    {
                        IxState = InteractiveContentState.Collapsing;
                    }
                    return;
                case InteractiveContentState.Collapsing:
                    _Delta = Helper.Clamp(_Delta - 0.023, 0, 1);
                    OnPerformancePosition(_Delta);
                    if (_Delta == 0)
                    {
                        IxState = InteractiveContentState.Idle;
                    }
                    break;
                case InteractiveContentState.Expanding:
                    _Delta = Helper.Clamp(_Delta + 0.06, 0, 1);
                    OnPerformancePosition(_Delta);
                    if(_Delta == 1)
                    {
                        IxState = InteractiveContentState.Idle;
                    }
                    break;
            }
        }

        #region OnSizeChanged / OnChildDesiredSizeChanged / OnContentChanged


        protected virtual void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_Presenter != null)
            {
                _Transformer?.Transform(this, _Presenter, Delta);
            }
        }

        protected override void OnChildDesiredSizeChanged(UIElement child)
        {
            if (_Presenter != null)
            {
                _Transformer?.Transform(this, _Presenter, Delta);
            }
            base.OnChildDesiredSizeChanged(child);
        }
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (_Presenter != null)
            {
                _Transformer?.Transform(this, _Presenter, Delta);
            }
            base.OnContentChanged(oldContent, newContent);
        }


        #endregion OnSizeChanged / OnChildDesiredSizeChanged / OnContentChanged

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

            Sampler.Start();
            base.OnApplyTemplate();
        }

        protected void OnPerformancePosition(double delta)
        {
            if(_Transformer != null && _Presenter != null)
            {
                // 
                // _Transformer.Transform(ParentElement ?? this, _Presenter, EasingFunction?.Ease(delta) ?? delta);
                _Transformer.Transform(ParentElement ?? this, _Presenter, delta);
            }
        }

        protected void OnSamplerChanged(DispatcherTimer newSampler, DispatcherTimer oldSampler)
        {
            newSampler.Tick += Sampling;
            newSampler.Interval = TimeSpan.FromMilliseconds(8);

            if (oldSampler != null)
            {
                oldSampler.Stop();
                oldSampler.Tick -= Sampling;
                newSampler.Start();
            }
        }
    }
}
