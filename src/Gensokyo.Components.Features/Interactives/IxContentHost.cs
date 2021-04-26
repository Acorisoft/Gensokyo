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
    /// <summary>
    /// 
    /// </summary>
    public partial class IxContentHost : ContentControl
    {
        public const string IxLeftName      = "PART_IxLeft";
        public const string IxRightName     = "PART_IxRight";
        public const string IxUpName        = "PART_IxUp";
        public const string IxDownName      = "PART_IxDown";

        static IxContentHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IxContentHost), new FrameworkPropertyMetadata(typeof(IxContentHost)));
        }

        private readonly DispatcherTimer _Sampler;
        private readonly SwipeRecognitor _Recognitor;

        private IxContentControl _IxLeft;
        private IxContentControl _IxRight;
        private IxContentControl _IxUp;
        private IxContentControl _IxDown;

        public IxContentHost()
        {
            _Sampler = new DispatcherTimer(DispatcherPriority.Render, Dispatcher);
            _Recognitor = new SwipeRecognitor(this);
            _Recognitor.SetSampler(_Sampler);
            _Recognitor.SwipeStarting += OnSwipeStarting;
            _Recognitor.SwipeProcessing += OnSwipeProcessing;
            _Recognitor.SwipeCompleted += OnSwipeCompleted;

            //
            //
            CommandBindings.Add(new CommandBinding(IxContentHostCommands.ToggleIxLeft, ToggleIxLeft , AlwaysCanExecute));
            CommandBindings.Add(new CommandBinding(IxContentHostCommands.ToggleIxRight, ToggleIxRight, AlwaysCanExecute));
            CommandBindings.Add(new CommandBinding(IxContentHostCommands.ToggleIxUp, ToggleIxUp, AlwaysCanExecute));
            CommandBindings.Add(new CommandBinding(IxContentHostCommands.ToggleIxDown, ToggleIxDown, AlwaysCanExecute));
            this.Unloaded += OnUnloaded;
        }


        private void OnSwipeStarting(SwipeDirection direction)
        {
            switch (direction)
            {
                case SwipeDirection.ToRight:
                    (_IxRight.Delta > .65 ? _IxRight : _IxLeft).IxState = InteractiveContentState.Dragging;
                    break;
                case SwipeDirection.ToBottom:
                    (_IxDown.Delta > .65 ? _IxDown : _IxUp).IxState = InteractiveContentState.Dragging;
                    break;
                case SwipeDirection.ToLeft:
                    (_IxLeft.Delta > .65 ? _IxLeft : _IxRight).IxState = InteractiveContentState.Dragging;
                    break;
                case SwipeDirection.ToTop:
                    (_IxUp.Delta > .65 ? _IxUp : _IxDown).IxState = InteractiveContentState.Dragging;
                    break;
            }
        }

        private void OnSwipeCompleted(object sender, EventArgs e)
        {
            _IxLeft.IxState =
            _IxUp.IxState =
            _IxRight.IxState =
            _IxDown.IxState = InteractiveContentState.Idle;
        }

        private void OnSwipeProcessing(double delta, SwipeDirection direction)
        {
            //Debug.WriteLine(delta);
            switch (direction)
            {
                case SwipeDirection.ToRight:
                    if (_IxRight.Delta > 0)
                    {

                        _IxRight.Delta = 1 - delta;
                    }
                    else
                    {
                        _IxLeft.Delta = delta;
                    }
                    break;
                case SwipeDirection.ToBottom:
                    if (_IxDown.Delta > 0)
                    {

                        _IxDown.Delta = 1 - delta;
                    }
                    else
                    {
                        _IxUp.Delta = delta;
                    }
                    break;
                case SwipeDirection.ToLeft:
                    if (_IxLeft.Delta > 0)
                    {

                        _IxLeft.Delta = 1 - delta;
                    }
                    else
                    {
                        _IxRight.Delta = delta;
                    }
                    break;
                case SwipeDirection.ToTop:
                    if(_IxUp.Delta > 0)
                    {

                        _IxUp.Delta = 1 - delta;
                    }
                    else
                    {
                        _IxDown.Delta = delta;
                    }
                    break;
            }
        }

        #region Toggle IxContentOpenState

        void AlwaysCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        void ToggleIxRight(object sender, ExecutedRoutedEventArgs e)
        {
            _IxRight.IsOpen = !_IxRight.IsOpen;
        }
        void ToggleIxUp(object sender, ExecutedRoutedEventArgs e)
        {
            _IxUp.IsOpen = !_IxUp.IsOpen;
        }
        void ToggleIxDown(object sender, ExecutedRoutedEventArgs e)
        {
            _IxDown.IsOpen = !_IxDown.IsOpen;
        }
        void ToggleIxLeft(object sender, ExecutedRoutedEventArgs e)
        {
            _IxLeft.IsOpen = !_IxLeft.IsOpen;
        }
        void ToggleSwipe(object sender, ExecutedRoutedEventArgs e)
        {
            SwipeRecognitor.IsEnable = !SwipeRecognitor.IsEnable;
        }

        #endregion Toggle IxContentOpenState

        protected virtual void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _Sampler.Stop();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _IxLeft = (IxContentControl)GetTemplateChild(IxLeftName);
            _IxRight = (IxContentControl)GetTemplateChild(IxRightName);
            _IxUp = (IxContentControl)GetTemplateChild(IxUpName);
            _IxDown = (IxContentControl)GetTemplateChild(IxDownName);

            _IxLeft.Sampler =
            _IxRight.Sampler =
            _IxUp.Sampler =
            _IxDown.Sampler = _Sampler;

            _IxLeft.ParentElement =
            _IxRight.ParentElement =
            _IxUp.ParentElement =
            _IxDown.ParentElement = this;

            _Sampler.Interval = TimeSpan.FromMilliseconds(8);
            _Sampler.Start();
        }
    }
}
