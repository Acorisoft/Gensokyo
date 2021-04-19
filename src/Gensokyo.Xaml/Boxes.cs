using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gensokyo.Xaml
{
    public static class Boxes
    {
        private sealed class Default<T>
        {
            public static readonly object DefaultObject = default(T);
        }
        public static object Box<T>() => Default<T>.DefaultObject;
    }

    public static class BooleanBoxes
    {
        public static readonly object True = true;
        public static readonly object False = false;
        public static object Boxes(bool condition) => condition ? True : False;
    }
}
