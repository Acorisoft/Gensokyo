using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Gensokyo.Components.Primitives;
using Gensokyo.Xaml.Commands;

namespace Gensokyo.Components.Interactives
{

    public class ToggleSwipeButton : PrimitiveButton
    {
        static ToggleSwipeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleSwipeButton), new FrameworkPropertyMetadata(typeof(ToggleSwipeButton)));
        }

        protected override void OnClick()
        {
            SwipeRecognitor.IsEnable = !SwipeRecognitor.IsEnable;
        }
    }

    public static class IxContentHostCommands 
    {
        static IxContentHostCommands()
        {
            ToggleIxLeft    = Create("ToggleIxLeft");
            ToggleIxRight   = Create("ToggleIxRight");
            ToggleIxUp      = Create("ToggleIxUp");
            ToggleIxDown    = Create("ToggleIxDown");
            ToggleSwipe     = Create("ToggleSwipe");
            ToggleEnable    = Create("ToggleEnable");
        }

        public static RoutedUICommand Create(string name)
        {
            return new RoutedUICommand(name, name, typeof(IxContentHostCommands));
        }

        /// <summary>
        /// 
        /// </summary>
        public static RoutedCommand ToggleIxLeft { get; }

        /// <summary>
        /// 
        /// </summary>
        public static RoutedCommand ToggleIxRight { get; }

        /// <summary>
        /// 
        /// </summary>
        public static RoutedCommand ToggleIxUp { get; }

        /// <summary>
        /// 
        /// </summary>
        public static RoutedCommand ToggleIxDown { get; }


        /// <summary>
        /// 
        /// </summary>
        public static RoutedCommand ToggleSwipe { get; }

        /// <summary>
        /// 
        /// </summary>
        public static RoutedCommand ToggleEnable { get; }
    }
}
