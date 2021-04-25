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
    /// <summary>
    /// <see cref="InteractiveHost"/> 表示一个具备交互性的内容容器。
    /// </summary>
    public partial class InteractiveHost : ContentControl
    {
        public const string IxContentName = "PART_IxContent";

        static InteractiveHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InteractiveHost), new FrameworkPropertyMetadata(typeof(InteractiveHost)));
        }

        private readonly DispatcherTimer _Timer;
        private readonly MouseGestureRecognition _Recognition;
        private IxContentControl _IxContent;

        public InteractiveHost()
        {
            _Timer = new DispatcherTimer(DispatcherPriority.Render, Dispatcher);
            _Recognition = new SweepDownRecognition();
            _Recognition.SetSampler(_Timer);
            _Recognition.Expanding += OnPerformanceIxContentPosition;
            _Recognition.Collapsing += OnPerformanceIxContentPosition;
            _Recognition.Dragging += OnPerformanceIxContentPosition;
        }

        void OnPerformanceIxContentPosition(double delta)
        {
            _IxContent.Delta = delta;
        }

        public override void OnApplyTemplate()
        {
            _IxContent = (IxContentControl)GetTemplateChild(IxContentName);
            _IxContent.ParentElement = this;
            _Recognition.SetInputElement(_IxContent);
            base.OnApplyTemplate();
        }
    }
}
