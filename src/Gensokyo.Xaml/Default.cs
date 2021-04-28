using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gensokyo.Xaml
{
    public static class Default
    {
        private static readonly ConcurrentDictionary<Type,object>  _Mapper = new ConcurrentDictionary<Type, object>();

        public static T Value<T>()
        {
            return default(T);
        }

        public static T GetDefaultValueOrRegister<T>()
        {
            if(_Mapper.TryGetValue(typeof(T),out var val))
            {
                return (T)val;
            }

            return default(T);
        }

        public static void DefaultValue<T>(T value)
        {
            _Mapper.TryAdd(typeof(T), value);
        }
    }
}
