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
    public enum SwipeDirection
    {
        ToLeft,
        ToRight,
        ToTop,

        /// <summary>
        /// 从上到下
        /// </summary>
        ToBottom
    }
    public delegate void SwipeStartingHandler(SwipeDirection direction);
    public delegate void SwipeProcessingHandler(double delta, SwipeDirection direction);

    public class SwipeRecognitor
    {

        class PointQueue
        {
            private Point _Start,_Last,_Current;
            private int _Time;

            public void Prepare(Point point)
            {
                _Start = point;
                _Current = point;
                _Time++;
            }

            public void Set(Point point)
            {
                _Last = _Current;
                _Current = point;
                _Time++;
            }

            public void Unset()
            {
                _Time = 0;
            }

            public double DeltaX => _Current.X - _Last.X;
            public double DeltaY => _Current.Y - _Last.Y;
            public double StartDeltaX => _Current.X - _Start.X;
            public double StartDeltaY => _Current.Y - _Start.Y;
            public bool IsEnable => _Time > 5;
            public bool IsPrepare => _Time < 1;
            public bool IsDetect => _Time == 6;
        }


        private DispatcherTimer _Timer;
        private double _Delta = 0;
        private SwipeDirection _Direction;
        private readonly PointQueue _Queue;
        private readonly FrameworkElement _Element;

        public SwipeRecognitor(FrameworkElement element)
        {
            _Queue = new PointQueue();
            _Element = element ?? throw new ArgumentNullException(nameof(element));
            Threshould = 160;
        }

        void Sampling(object sender, EventArgs e)
        {
            if (IsEnable)
            {
                return;
            }

            if (Mouse.LeftButton == MouseButtonState.Pressed || Mouse.RightButton == MouseButtonState.Pressed)
            {
                var position = Mouse.GetPosition(_Element);

                if (_Queue.IsPrepare)
                {
                    _Queue.Prepare(position);
                }
                else
                {
                    _Queue.Set(position);
                }
                if (_Queue.IsEnable)
                {
                    Detect();
                }
            }
            else if (_Queue.IsEnable)
            {
                _Delta = 0;
                //
                // Fire SwipeCompleted Event
                SwipeCompleted?.Invoke(this, new EventArgs());
                _Queue.Unset();
            }
        }

        void Detect()
        {
            var deltaX = _Queue.DeltaX;
            var deltaY = _Queue.DeltaY;

            if (_Queue.IsDetect)
            {
                _Direction = GetSwipeDirection(_Queue.StartDeltaX, _Queue.StartDeltaY);
                SwipeStarting?.Invoke(_Direction);
                // Fire SwipeStarting

                SwipeStarted?.Invoke(0, _Direction);

            }
            else
            {

                _Delta = Helper.Clamp(_Delta + GetDelta(_Direction, deltaX, deltaY), 0d, 1d);

                // Fire SwipeProcessing
                SwipeProcessing?.Invoke(_Delta, _Direction);
            }
        }

        static SwipeDirection GetSwipeDirection(double x, double y)
        {
            var angle = GetAngle(x , y);

            // -pi          -180 180
            // -3/4 pi      -135 225
            // -1/2 pi      -90  270
            // -1/4 pi      -45  315

            if (Range(angle, 0, 48) || Range(angle, -45, 0))
            {
                return SwipeDirection.ToRight;
            }

            if (Range(angle, -180, -135) || Range(angle, 135, 180))
            {
                return SwipeDirection.ToLeft;
            }

            if (Range(angle, 45, 135))
            {
                return SwipeDirection.ToTop;
            }

            if (Range(angle, -135, -45))
            {
                return SwipeDirection.ToBottom;
            }

            return SwipeDirection.ToBottom;
        }

        static bool Range(double value, double min, double max)
        {
            return min <= value && value < max;
        }

        double GetDelta(SwipeDirection direction, double x, double y)
        {
            switch (direction)
            {
                default:
                case SwipeDirection.ToBottom:
                    return y / Threshould;
                case SwipeDirection.ToLeft:
                    return -x / Threshould;
                case SwipeDirection.ToRight:
                    return x / Threshould;
                case SwipeDirection.ToTop:
                    return -y / Threshould;
            }
        }

        static int GetAngle(double x, double y)
        {
            return (int)(Math.Atan2(-y, x) * 180 / Math.PI);
        }

        public void SetSampler(DispatcherTimer sampler)
        {
            if (_Timer != null)
            {
                _Timer.Tick -= Sampling;
                _Timer.Stop();
            }

            _Timer = sampler ?? throw new ArgumentNullException(nameof(sampler));
            _Timer.Tick += Sampling;
            _Timer.Start();
        }

        public event EventHandler SwipeCompleted;
        public event SwipeStartingHandler SwipeStarting;
        public event SwipeProcessingHandler SwipeStarted;
        public event SwipeProcessingHandler SwipeProcessing;

        /// <summary>
        /// 获取或设置一个值，该值用于指示全局 <see cref="SwipeRecognitor"/> 实例，跳过手势识别。
        /// </summary>
        public static bool IsEnable { get; set; } = true;
        public int Threshould { get; set; }
    }
}
