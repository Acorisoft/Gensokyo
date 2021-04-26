using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Gensokyo.Xaml.Commands;

namespace Gensokyo.Components.Interactives
{
    public class IxContentHostCommands : UICommandBase
    {
        static IxContentHostCommands()
        {
            ToggleIxLeft = Create("ToggleIxLeft");
            ToggleIxRight   = Create("ToggleIxRight");
            ToggleIxUp      = Create("ToggleIxUp");
            ToggleIxDown    = Create("ToggleIxDown");
        }

        /// <summary>
        /// 
        /// </summary>
        public static RoutedUICommand ToggleIxLeft { get; }

        /// <summary>
        /// 
        /// </summary>
        public static RoutedUICommand ToggleIxRight { get; }

        /// <summary>
        /// 
        /// </summary>
        public static RoutedUICommand ToggleIxUp { get; }

        /// <summary>
        /// 
        /// </summary>
        public static RoutedUICommand ToggleIxDown { get; }
    }
}
