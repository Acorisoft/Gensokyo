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
    partial class IxContentControl
    {
        public bool IsStandalone
        {
            get => (bool)GetValue(IsStandaloneProperty);
            set => SetValue(IsStandaloneProperty, value);
        }

        public DispatcherTimer Sampler
        {
            get => (DispatcherTimer)GetValue(SamplerProperty);
            set => SetValue(SamplerProperty, value);
        }


        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }


        /// <summary>
        /// 获取或设置当前状态。
        /// </summary>
        public InteractiveContentState IxState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 只有当 <see cref="IxState"/>的状态为 <see cref="InteractiveContentState.Dragging"/> 的情况下才能直接修改当前属性的值。
        /// </remarks>
        public double Delta
        {
            get => _Delta;
            set
            {
                if(IxState == InteractiveContentState.Dragging)
                {
                    _Delta = Helper.Clamp(value, 0, 1);
                    OnPerformancePosition(_Delta);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ExpandDirection Direction
        {
            get => (ExpandDirection)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }

        public EasingFunctionBase EasingFunction
        {
            get => (EasingFunctionBase)GetValue(EasingFunctionProperty);
            set => SetValue(EasingFunctionProperty, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public FrameworkElement ParentElement { get; set; }
    }
}
