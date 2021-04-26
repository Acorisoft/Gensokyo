using Gensokyo.Xaml;
using ReactiveUI;
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

namespace Gensokyo.Components.Windows
{
    partial class InteractiveWindow
    {
        #region DependencyProperties

        /// <summary>
        /// The view model dependency property.
        /// </summary>
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(
                "ViewModel",
                typeof(IRoutableViewModel),
                typeof(InteractiveWindow),
                new PropertyMetadata(null));

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty DialogProperty;

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyPropertyKey DialogPropertyKey;


        public static readonly DependencyProperty TitleBarStringFormatProperty = DependencyProperty.Register(
            "TitleBarStringFormat",
            typeof(string),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TitleBarTemplateSelectorProperty = DependencyProperty.Register(
            "TitleBarTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TitleBarTemplateProperty = DependencyProperty.Register(
            "TitleBarTemplate",
            typeof(DataTemplate),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TitleBarProperty = DependencyProperty.Register(
            "TitleBar",
            typeof(object),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            "Color",
            typeof(Brush),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        //-------------------------------------------------------------------------------------------------
        //
        //  PropertyChangedCallback
        //
        //-------------------------------------------------------------------------------------------------

        private static void OnDialogChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InteractiveWindow window && e.NewValue != null)
            {
                //
                // Fire DialogShow Event
                window.RaiseEvent(new RoutedEventArgs
                {
                    RoutedEvent = DialogShowEvent
                });
            }
        }
        #endregion DependencyProperties

        #region SystemCommands


        private void OnWindowClose(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void OnWindowMinimum(object sender, ExecutedRoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void OnWindowRestore(object sender, ExecutedRoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }


        #endregion SystemCommands

        //-------------------------------------------------------------------------------------------------
        //
        //  RoutedEvents
        //
        //-------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        public static readonly RoutedEvent DialogShowEvent =
            EventManager.RegisterRoutedEvent("DialogShow", RoutingStrategy.Bubble,typeof(EventHandler),typeof(InteractiveWindow));

        /// <summary>
        /// 
        /// </summary>
        public static readonly RoutedEvent DialogCloseEvent =
            EventManager.RegisterRoutedEvent("DialogClose", RoutingStrategy.Bubble,typeof(EventHandler),typeof(InteractiveWindow));

        //-------------------------------------------------------------------------------------------------
        //
        //  Events
        //
        //-------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        public event RoutedEventHandler DialogClose
        {
            add => AddHandler(DialogCloseEvent, value);
            remove => RemoveHandler(DialogCloseEvent, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public event RoutedEventHandler DialogShow
        {
            add => AddHandler(DialogShowEvent, value);
            remove => RemoveHandler(DialogShowEvent, value);
        }

        public static readonly DependencyProperty LeftSideStringFormatProperty = DependencyProperty.Register(
            "LeftSideStringFormat",
            typeof(string),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty LeftSideTemplateSelectorProperty = DependencyProperty.Register(
            "LeftSideTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty LeftSideTemplateProperty = DependencyProperty.Register(
            "LeftSideTemplate",
            typeof(DataTemplate),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty RightSideStringFormatProperty = DependencyProperty.Register(
            "RightSideStringFormat",
            typeof(string),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty RightSideTemplateSelectorProperty = DependencyProperty.Register(
            "RightSideTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty RightSideTemplateProperty = DependencyProperty.Register(
            "RightSideTemplate",
            typeof(DataTemplate),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty RightSideProperty = DependencyProperty.Register(
            "RightSide",
            typeof(object),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TopSideProperty = DependencyProperty.Register(
            "TopSide",
            typeof(object),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TopSideStringFormatProperty = DependencyProperty.Register(
            "TopSideStringFormat",
            typeof(string),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TopSideTemplateSelectorProperty = DependencyProperty.Register(
            "TopSideTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TopSideTemplateProperty = DependencyProperty.Register(
            "TopSideTemplate",
            typeof(DataTemplate),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty LeftSideProperty = DependencyProperty.Register(
            "LeftSide",
            typeof(object),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty BottomSideStringFormatProperty = DependencyProperty.Register(
            "BottomSideStringFormat",
            typeof(string),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty BottomSideTemplateSelectorProperty = DependencyProperty.Register(
            "BottomSideTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty BottomSideTemplateProperty = DependencyProperty.Register(
            "BottomSideTemplate",
            typeof(DataTemplate),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));

        public static readonly DependencyProperty BottomSideProperty = DependencyProperty.Register(
            "BottomSide",
            typeof(object),
            typeof(InteractiveWindow),
            new PropertyMetadata(null));
    }
}
