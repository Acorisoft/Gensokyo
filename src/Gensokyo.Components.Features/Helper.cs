using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gensokyo.Components
{
    class Helper
    {
		private static void ThrowMinMaxException<T>(T min, T max)
		{
			throw new ArgumentException();
		}

		public static byte Clamp(byte value, byte min, byte max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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

		public static decimal Clamp(decimal value, decimal min, decimal max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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

		public static double Clamp(double value, double min, double max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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

		public static short Clamp(short value, short min, short max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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

		public static int Clamp(int value, int min, int max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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

		public static long Clamp(long value, long min, long max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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

		public static sbyte Clamp(sbyte value, sbyte min, sbyte max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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

		public static float Clamp(float value, float min, float max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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

		public static ushort Clamp(ushort value, ushort min, ushort max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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

		public static uint Clamp(uint value, uint min, uint max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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


		public static ulong Clamp(ulong value, ulong min, ulong max)
		{
			if (min > max)
			{
				ThrowMinMaxException(min, max);
			}
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
	}
}
