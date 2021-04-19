using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gensokyo.Xaml.Converters
{
    static class ColorConverters
    {
        internal static readonly ConcurrentDictionary<string , Brush> BrushCache = new ConcurrentDictionary<string, Brush>();
        internal static readonly ConcurrentDictionary<Brush , string> StringCache = new ConcurrentDictionary<Brush, string>();
    }
}
