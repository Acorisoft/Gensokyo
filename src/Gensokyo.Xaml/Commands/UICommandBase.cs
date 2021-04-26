using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Gensokyo.Xaml.Commands
{
    public abstract class UICommandBase
    {
        protected static RoutedUICommand Create(string name)
        {
            return new RoutedUICommand(name, name, typeof(UICommandBase));
        }
    }
}
