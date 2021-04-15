using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gensokyo.Xaml.ColorSpace
{
    public static class HSBColorSpace
    {
        static double H(double r, double g, double b, double max, double delta)
        {
            if (delta == 0)
            {
                return 0;
            }
            else if (max == r)
            {
                return 60 * (((g - r) / delta) % 6);
            }
            else if (max == g)
            {
                return 60 * (((b - r) / delta) + 2);
            }
            else
            {

                return 60 * (((r - g) / delta) + 4);
            }
        }

        public static T FromRGB<T>(int r, int g, int b, Func<double, double, double, T> callback)
        {
            r = Clamp(r, 0, 255);
            g = Clamp(g, 0, 255);
            b = Clamp(b, 0, 255);

            var r1 = r / 255d;
            var g1 = g / 255d;
            var b1 = b / 255d;
            var max = Math.Max(r1 , Math.Max(g1 , b1));
            var min = Math.Min(r1 , Math.Min(g1 , b1));
            var delta = max - min;


            var h = H(r1 , g1 , b1 , max , delta);
            var s = max == 0 ? 0 : delta / max;
            return callback(h, s, max);
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static double Clamp(double value, double min, double max)
        {
            if (value < min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="h">色相，取值范围为0-360</param>
        /// <param name="s">饱和度，取值范围为0-1</param>
        /// <param name="v">亮度，取值范围为0-1</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static T FromHSB<T>(double h, double s, double v, Func<int, int, int, T> callback)
        {
            h %= 360;
            s = Clamp(s, 0, 1);
            v = Clamp(v, 0, 1);

            var c = v * s;
            var x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            var m = v - c;
            double r,g,b;

            if (0 <= h && h < 60)
            {
                r = c;
                g = x;
                b = 0;
            }
            else if (60 <= h && h < 120)
            {
                r = x;
                g = c;
                b = 0;
            }
            else if (120 <= h && h < 180)
            {
                r = 0;
                g = c;
                b = x;
            }
            else if (180 <= h && h < 240)
            {
                r = 0;
                g = x;
                b = c;
            }
            else if (240 <= h && h < 300)
            {
                r = x;
                g = 0;
                b = c;
            }
            else
            {
                r = c;
                g = 0;
                b = x;
            }

            return callback((int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));
        }
    }
}
