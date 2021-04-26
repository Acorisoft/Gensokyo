using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gensokyo.Components.Windows
{
    public partial class InteractiveWindow : Window
    {
        static InteractiveWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InteractiveWindow), new FrameworkPropertyMetadata(typeof(InteractiveWindow)));
            DialogPropertyKey = DependencyProperty.RegisterReadOnly(
                "Dialog",
                typeof(object),
                typeof(InteractiveWindow),
                new PropertyMetadata(null, OnDialogChanged));
            DialogProperty = DialogPropertyKey.DependencyProperty;
        }

        public InteractiveWindow() : base()
        {
            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnWindowClose));
            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnWindowMinimum));
            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnWindowRestore));
            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnWindowRestore));
        }

    }
}
